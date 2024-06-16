using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Entrance;
using WarehouseMaster.Core.DTO.Shipment;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Impl;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Service.Impl
{
    public class EntranceService : IEntranceService
    {
        private readonly IEntranceRepository _entranceRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IStafferRepository _stafferRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public EntranceService(IEntranceRepository entranceRepository, IMapper mapper, IWarehouseRepository warehouseRepository, IStafferRepository stafferRepository, IProductRepository productRepository)
        {
            _entranceRepository = entranceRepository;
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
            _stafferRepository = stafferRepository;
            _productRepository = productRepository;
        }

        public async Task<OperationResult<int>> CreateEntranceAsync(EntranceRequest request)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(request.WarehouseId);
            var staffer = await _stafferRepository.GetByIdAsync(request.StafferId);
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (warehouse == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Склад не найден");
            if (staffer == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Сотрудник не найден");
            if (product == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Товар не найден");
            var entrance = _mapper.Map<Entrance>(request);
            entrance.Staffer = staffer;
            entrance.Warehouse = warehouse;
            entrance.Product = product;
            entrance.Status = false;
            var result = await _entranceRepository.CreateAsync(entrance);
            if (result != 0) return new OperationResult<int>(result);
            return OperationResult<int>.Fail(OperationCode.Error, "Ошибка сохранения данных поступления");
        }

        public async Task<OperationResult<bool>> DeleteEntranceAsync(int id)
        {
            var result = await _entranceRepository.DeleteAsync(id);
            return new OperationResult<bool>(result);
        }

        public async Task<OperationResult<IEnumerable<EntranceResponse>>> GetAllEntranceAsync(int id)
        {
            var entrance = await _entranceRepository.GetAll(id);
            return new OperationResult<IEnumerable<EntranceResponse>>(_mapper.Map<IEnumerable<EntranceResponse>>(entrance));
        }

        public async Task<OperationResult<EntranceResponse>> GetEntranceByIdAsync(int id)
        {
            var entrance = await _entranceRepository.GetByIdAsync(id);
            return new OperationResult<EntranceResponse>(_mapper.Map<EntranceResponse>(entrance));
        }

        public Task<OperationResult<bool>> IsExistEntranceAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
