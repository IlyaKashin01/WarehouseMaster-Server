using AuthService.Core.DTO.Auth;
using WarehouseMaster.Common.OperationResult;

namespace AuthService.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResult<AuthResponse>> AuthenticateAsync(AuthRequest request);
        Task<OperationResult<int>> SingupAsync(SignupRequest request);
    }
}
