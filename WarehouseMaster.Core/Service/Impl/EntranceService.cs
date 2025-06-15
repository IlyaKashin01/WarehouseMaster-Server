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
    public class EntranceService(
        IProductService productService,
        IEntranceRepository entranceRepository,
        IMapper mapper,
        IWarehouseRepository warehouseRepository,
        IStafferRepository stafferRepository,
        IProductRepository productRepository,
        IProviderRepository providerRepository)
        : IEntranceService
    {
        public async Task<OperationResult<int>> CreateEntranceAsync(EntranceRequest request)
        {
            var warehouse = await warehouseRepository.GetByIdAsync(request.WarehouseId);
            var staffer = await stafferRepository.GetByIdAsync(request.StafferId);

            if (warehouse == null) return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Склад не найден");
            if (staffer == null)
                return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "Сотрудник не найден");
            
            var products = new List<Product>();
            foreach (var productModel in request.Products.Select(product => mapper.Map<Product>(product)))
            {
                var provider = await providerRepository.GetByIdAsync(productModel.ProviderId);
                productModel.Warehouse = warehouse;
                productModel.WarehouseId = warehouse.Id;
                productModel.Staffer = staffer;
                productModel.StafferId = staffer.Id;
                productModel.Provider = provider;
                productModel.ProviderId = provider.Id;
                productModel.Entrance = null;
                productModel.EntranceId = null;
                productModel.QRCode = productService.GenerateQrCode(productModel);

                var productId = await productRepository.CreateAsync(productModel);
                var productEntity = await productRepository.GetByIdAsync(productId);
                products.Add(productEntity);
            }
            
            var entrance = mapper.Map<Entrance>(request);
            entrance.Staffer = staffer;
            entrance.StafferId = staffer.Id;
            entrance.Warehouse = warehouse;
            entrance.WarehouseId = warehouse.Id;
            entrance.Products = products;
            entrance.Status = true;

            var result = await entranceRepository.CreateAsync(entrance);
            if (result != 0)
            {
                var entranceEntity = await entranceRepository.GetByIdAsync(result);
                foreach (var product in products)
                {
                    
                    if (entranceEntity  != null)
                    {
                        product.Entrance = entranceEntity;
                        product.EntranceId = entranceEntity.Id;
                        
                        var updated = await productRepository.UpdateAsync(product);
                        if (updated)
                            return new OperationResult<int>(result);
                    }
                }
            }

            return result != 0
                ? new OperationResult<int>(result)
                : OperationResult<int>.Fail(OperationCode.Error, "Ошибка сохранения данных поступления");
        }

        public async Task<OperationResult<bool>> DeleteEntranceAsync(int id)
        {
            var result = await entranceRepository.DeleteAsync(id);
            return new OperationResult<bool>(result);
        }

        public async Task<OperationResult<IEnumerable<EntranceResponse>>> GetAllEntranceAsync(int id)
        {
            var entrance = await entranceRepository.GetAll(id);
            return new OperationResult<IEnumerable<EntranceResponse>>(
                mapper.Map<IEnumerable<EntranceResponse>>(entrance));
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