using ActorService.Data.Repositories.Interfaces;
using AutoMapper;
using ProductService.Data.Repositories.Interfaces;
using Warehouse.Core.Services.Interfaces;
using WarehouseMaster.Common.DTO.Entrance;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Domain.Entities;
using WarehouseService.Data.Repositories.Interfaces;

namespace Warehouse.Core.Services.Impl
{
    public class EntranceService(
        IEntranceRepository entranceRepository,
        IMapper mapper,
        IWarehouseRepository warehouseRepository,
        IStafferRepository stafferRepository,
        IProductRepository productRepository)
        : IEntranceService
    {
        public async Task<OperationResult<int>> CreateEntranceAsync(EntranceRequest request)
        {
            var warehouse = await warehouseRepository.GetByIdAsync(request.WarehouseId);
            var staffer = await stafferRepository.GetByIdAsync(request.StafferId);
            var product = await productRepository.GetByIdAsync(request.ProductId);
            if (warehouse == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Склад не найден");
            if (staffer == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Сотрудник не найден");
            if (product == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Товар не найден");
            var entrance = mapper.Map<Entrance>(request);
            entrance.Staffer = staffer;
            entrance.Warehouse = warehouse;
            entrance.Product = product;
            entrance.Status = false;
            var result = await entranceRepository.CreateAsync(entrance);
            if (result != 0) return new OperationResult<int>(result);
            return OperationResult<int>.Fail(OperationCode.Error, "Ошибка сохранения данных поступления");
        }

        public async Task<OperationResult<bool>> DeleteEntranceAsync(int id)
        {
            var result = await entranceRepository.DeleteAsync(id);
            return new OperationResult<bool>(result);
        }

        public async Task<OperationResult<IEnumerable<EntranceResponse>>> GetAllEntranceAsync(int id)
        {
            var entrance = await entranceRepository.GetAll(id);
            return new OperationResult<IEnumerable<EntranceResponse>>(mapper.Map<IEnumerable<EntranceResponse>>(entrance));
        }

        public async Task<OperationResult<EntranceResponse>> GetEntranceByIdAsync(int id)
        {
            var entrance = await entranceRepository.GetByIdAsync(id);
            return new OperationResult<EntranceResponse>(mapper.Map<EntranceResponse>(entrance));
        }

        public Task<OperationResult<bool>> IsExistEntranceAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
