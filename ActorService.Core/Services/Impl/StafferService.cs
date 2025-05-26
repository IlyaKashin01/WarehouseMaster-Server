using ActorService.Core.Services.Interfaces;
using ActorService.Data.Repositories.Interfaces;
using AuthService.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WarehouseMaster.Common.DTO.Staffer;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Domain.Entities;
using WarehouseService.Data.Repositories.Interfaces;

namespace ActorService.Core.Services.Impl
{
    public class StafferService(
        IMapper mapper,
        ILogger<StafferService> logger,
        IStafferRepository stafferRepository,
        IPersonRepository personRepository,
        IWarehouseRepository warehouseRepository)
        : IStafferService
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<OperationResult<int>> CreateStafferAsync(StafferRequest request)
        {
            if (await _personRepository.CheckExistPersonByEmailAsync(request.Email))
            {
                logger.LogError($"Попытка зарегистрировать сущесвующего сотрудника");
                return OperationResult<int>.Fail(OperationCode.AlreadyExists,
                    "Сотрудник уже зарегистрирован в системе");
            }

            logger.LogInformation($"Обращение к методу создания записи о сотруднике");
            var person = mapper.Map<Person>(request);
            var personId = await _personRepository.CreateAsync(person);
            var staffer = mapper.Map<Staffer>(request);
            staffer.PersonId = personId;
            var warehouse = await warehouseRepository.GetByIdAsync(request.WarehouseId);
            if (warehouse == null)
            {
                logger.LogError($"Попытка зарегистрировать сотрудника для не существующего склада");
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "Склад не найден");
            }
            else
            {
                staffer.Person = person;
                staffer.WarehouseId = warehouse.Id;
                staffer.Warehouse = warehouse;
                var response = await stafferRepository.CreateAsync(staffer);
                return new OperationResult<int>(response);
            }
        }

        public async Task<OperationResult<bool>> DeleteStafferAsync(int id)
        {
            logger.LogInformation($"Обращение к методу удаления записи о сотруднике");
            var response = await stafferRepository.DeleteAsync(id);
            return new OperationResult<bool>(response);
        }

        public async Task<OperationResult<IEnumerable<StafferResponse>>> GetAllStaffersAsync()
        {
            var staffers = await stafferRepository.GetAllAsync();
            var response = mapper.Map<IEnumerable<StafferResponse>>(staffers);
            return new OperationResult<IEnumerable<StafferResponse>>(response);
        }

        public async Task<OperationResult<StafferResponse>> GetStafferByIdAsync(int id)
        {
            logger.LogInformation($"Обращение к методу получения записи о сотруднике по id");
            var response = await stafferRepository.GetByIdAsync(id);
            return new OperationResult<StafferResponse>(mapper.Map<StafferResponse>(response));
        }

        public async Task<OperationResult<bool>> IsExistStafferAsync(int id)
        {
            logger.LogInformation($"Обращение к методу проверки существования записи о сотруднике по id");
            var response = await stafferRepository.IsExistAsync(id);
            return new OperationResult<bool>(response);
        }
    }
}