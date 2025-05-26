using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthService.Core.DTO.Auth;
using AuthService.Core.Services.Interfaces;
using AuthService.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WarehouseMaster.Common.Auth;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Domain.Entities;
using BC = BCrypt.Net.BCrypt;


namespace AuthService.Core.Services.Impl
{
    public class AuthService(IPersonRepository personRepository, IMapper mapper, IOptions<AuthOptions> authOptions)
        : IAuthService
    {
        private readonly AuthOptions _authOptions = authOptions.Value;

        public async Task<OperationResult<AuthResponse>> AuthenticateAsync(AuthRequest request)
        {
            var person = await personRepository.FindByLoginAsync(request.Login);

            if (person == null)
                return OperationResult<AuthResponse>.Fail(
                    OperationCode.Unauthorized,
                    $"Пользователь с логином {request.Login} не зарегистрирован");

            if (!BC.Verify(request.Password, person.PasswordHash))
                return OperationResult<AuthResponse>.Fail(OperationCode.ValidationError, "Неверный пароль");
            var token = GenerateJwtTokenAsync(person);
            var response = new AuthResponse
            {
                Person = mapper.Map<PersonResponse>(person),
                Token = token
            };

            return new OperationResult<AuthResponse>(response);
        }

        public async Task<OperationResult<int>> SingupAsync(SignupRequest request)
        {
            if (await personRepository.FindByLoginAsync(request.Login) is not null)
                return OperationResult<int>.Fail(
                    OperationCode.AlreadyExists,
                    $"Пользователь с логином {request.Login} уже существует");

            var person = mapper.Map<Person>(request);

            person.PasswordHash = BC.HashPassword(request.Password);
            person.Role = "admin";
           
            var result = await personRepository.CreateAsync(person);

            return new OperationResult<int>(result);
        }

        private string GenerateJwtTokenAsync(Person person)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Sid, person.Id.ToString()),
                new Claim(ClaimTypes.Role, person!.Role)
            };
            var jwt = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_authOptions.TokenLifeTime),  // действие токена истекает через 7 дней
                signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
