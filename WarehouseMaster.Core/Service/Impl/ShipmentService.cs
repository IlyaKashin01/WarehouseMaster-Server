using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Shipment;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Service.Impl
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IStafferRepository _stafferRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ShipmentService(IMapper mapper, IShipmentRepository shipmentRepository, IWarehouseRepository warehouseRepository, IStafferRepository stafferRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _shipmentRepository = shipmentRepository;
            _warehouseRepository = warehouseRepository;
            _stafferRepository = stafferRepository;
            _productRepository = productRepository;
        }

        public async Task<OperationResult<int>> CreateShipmentAsync(ShipmentRequest request)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(request.WarehouseId);
            var staffer = await _stafferRepository.GetByIdAsync(request.StafferId);
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (warehouse == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Склад не найден");
            if (staffer == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Сотрудник не найден");
            if (product == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Товар не найден");
            var shipment = _mapper.Map<Shipment>(request);
            shipment.Staffer = staffer;
            shipment.Warehouse = warehouse;
            shipment.Product = product;
            shipment.Status = false;
            var result = await _shipmentRepository.CreateAsync(shipment);
            if (result != 0) return new OperationResult<int>(result);
            return OperationResult<int>.Fail(OperationCode.Error, "Ошибка сохранения данных отгрузки");
        }

        public async Task<OperationResult<bool>> DeleteShipmentAsync(int id)
        {
            var result = await _shipmentRepository.DeleteAsync(id); 
            return new OperationResult<bool>(result);
        }

        public async Task<OperationResult<IEnumerable<ShipmentResponse>>> GetAllShipmentAsync(int warehouseId)
        {
            var shipment = await _shipmentRepository.GetAllShipmentAsync(warehouseId);
            return new OperationResult<IEnumerable<ShipmentResponse>>(_mapper.Map<IEnumerable<ShipmentResponse>>(shipment));
        }

        public async Task<OperationResult<ShipmentResponse>> GetShipmentByIdAsync(int id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);
            return new OperationResult<ShipmentResponse>(_mapper.Map<ShipmentResponse>(shipment));
        }

        public Task<OperationResult<bool>> IsExistShipmentAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
