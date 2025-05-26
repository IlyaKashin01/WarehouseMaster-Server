using ActorService.Data.Repositories.Interfaces;
using AutoMapper;
using ProductService.Data.Repositories.Interfaces;
using Warehouse.Core.Services.Interfaces;
using WarehouseMaster.Common.DTO.Shipment;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Domain.Entities;
using WarehouseService.Data.Repositories.Interfaces;

namespace Warehouse.Core.Services.Impl
{
    public class ShipmentService(
        IMapper mapper,
        IShipmentRepository shipmentRepository,
        IWarehouseRepository warehouseRepository,
        IStafferRepository stafferRepository,
        IProductRepository productRepository)
        : IShipmentService
    {
        private readonly IWarehouseRepository _warehouseRepository = warehouseRepository;
        private readonly IStafferRepository _stafferRepository = stafferRepository;

        public async Task<OperationResult<int>> CreateShipmentAsync(ShipmentRequest request)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(request.WarehouseId);
            var staffer = await _stafferRepository.GetByIdAsync(request.StafferId);
            var product = await productRepository.GetByIdAsync(request.ProductId);
            if (warehouse == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Склад не найден");
            if (staffer == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Сотрудник не найден");
            if (product == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Товар не найден");
            var shipment = mapper.Map<Shipment>(request);
            shipment.Staffer = staffer;
            shipment.Warehouse = warehouse;
            shipment.Product = product;
            shipment.Status = false;
            var result = await shipmentRepository.CreateAsync(shipment);
            if (result != 0) return new OperationResult<int>(result);
            return OperationResult<int>.Fail(OperationCode.Error, "Ошибка сохранения данных отгрузки");
        }

        public async Task<OperationResult<bool>> DeleteShipmentAsync(int id)
        {
            var result = await shipmentRepository.DeleteAsync(id); 
            return new OperationResult<bool>(result);
        }

        public async Task<OperationResult<IEnumerable<ShipmentResponse>>> GetAllShipmentAsync(int warehouseId)
        {
            var shipment = await shipmentRepository.GetAllShipmentAsync(warehouseId);
            return new OperationResult<IEnumerable<ShipmentResponse>>(mapper.Map<IEnumerable<ShipmentResponse>>(shipment));
        }

        public async Task<OperationResult<ShipmentResponse>> GetShipmentByIdAsync(int id)
        {
            var shipment = await shipmentRepository.GetByIdAsync(id);
            return new OperationResult<ShipmentResponse>(mapper.Map<ShipmentResponse>(shipment));
        }

        public Task<OperationResult<bool>> IsExistShipmentAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
