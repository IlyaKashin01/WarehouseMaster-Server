using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Staffer;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Impl;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Service.Impl
{
    public class StafferService : IStafferService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<StafferService> _logger;
        private readonly IStafferRepository _stafferRepository;

        public StafferService(IMapper mapper, ILogger<StafferService> logger, IStafferRepository stafferRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _stafferRepository = stafferRepository;
        }

        public async Task<OperationResult<int>> CreateStafferAsync(StafferRequest request)
        {
            if(await _stafferRepository.GetByIdAsync(request.AccountId) != null) 
            {
                _logger.LogError($"Попытка зарегистрировать сущесвующего сотрудника");
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "Сотрудник уже зарегистрирован в системе");
            }
            _logger.LogInformation($"Обращение к методу создания записи о сотруднике");
            var staffer = _mapper.Map<Staffer>(request);
            var response = await _stafferRepository.CreateAsync(staffer);
            return new OperationResult<int>(response);
        }

        public async Task<OperationResult<bool>> DeleteStafferAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу удаления записи о сотруднике");
            var response  = await _stafferRepository.DeleteAsync(id);
            return new OperationResult<bool>(response);
        }

        public async Task<OperationResult<StafferResponse>> GetStafferByIdAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу получения записи о сотруднике по id");
            var response = await _stafferRepository.GetByIdAsync(id);
            return new OperationResult<StafferResponse>(_mapper.Map<StafferResponse>(response));
        }

        public async Task<OperationResult<bool>> IsExistStafferAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу проверки существования записи о сотруднике по id");
            var response = await _stafferRepository.IsExistAsync(id);
            return new OperationResult<bool>(response);
        }
    }
}
