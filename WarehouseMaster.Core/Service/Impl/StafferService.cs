using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //private readonly ILogger _logger;
        private readonly IStafferRepository _stafferRepository;

        public StafferService(IMapper mapper, /*ILogger logger, */IStafferRepository stafferRepository  )
        {
            _mapper = mapper;
            //_logger = logger;
            _stafferRepository = stafferRepository;
        }

        public async Task<int> CreateStafferAsync(StafferRequest request)
        {
            //_logger.LogInformation($"Обращение к методу создания сотрудника для объекта: {request}");
            var staffer = _mapper.Map<Staffer>(request);
            return await _stafferRepository.CreateAsync(staffer);
        }

        public Task<bool> DeleteStafferAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StafferResponse> GetStafferByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistStafferAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
