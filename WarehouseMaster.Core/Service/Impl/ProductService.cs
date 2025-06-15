using AutoMapper;
using Microsoft.Extensions.Logging;
using QRCoder;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using WarehouseMaster.Common.OperationResult;

namespace WarehouseMaster.Core.Service.Impl
{
    public class ProductService(
        IMapper mapper,
        IProductRepository productRepository,
        ILogger<ProductService> logger,
        IStafferRepository stafferRepository,
        IWarehouseRepository warehouseRepository)
        : IProductService
    {
        public async Task<OperationResult<int>> CreateProductAsync(ProductRequest request)
        {
            logger.LogInformation($"Обращение к методу создания продукта");
            var product = mapper.Map<Product>(request);
            var staffer = await stafferRepository.GetByIdAsync(product.StafferId);
            var warehouse = await warehouseRepository.GetByIdAsync(request.WarehouseId);
            if ( staffer != null && warehouse != null)
            {
                product.Staffer = staffer;
                product.Warehouse = warehouse;
            }
            else {
                logger.LogError("Попытка добавления товара без указания категории или сотрудника");
                return OperationResult<int>.Fail(OperationCode.ValidationError, "для добавления продукта необходимо указать категорию и сотрудника");
            }
            
            product.QRCode = GenerateQrCode(product);
            var response = await productRepository.CreateAsync(product);
            return new OperationResult<int>(response);
        }

        public async Task<OperationResult<bool>> DeleteProductAsync(int id)
        {
            logger.LogInformation($"Обращение к методу удаления продукта");
            var reponse = await productRepository.DeleteAsync(id);
            return new OperationResult<bool>(reponse);
        }

        public async Task<OperationResult<ProductResponse>> GetProductByIdAsync(int id)
        {
            logger.LogInformation($"Обращение к методу получения продукта");
            var response = await productRepository.GetByIdAsync(id);
            return new OperationResult<ProductResponse>(mapper.Map<ProductResponse>(response));
        }
        
        public async Task<OperationResult<IEnumerable<ProductResponse>>> GetAllProductsByWarehouseAsync(int warehouseId)
        {
            logger.LogInformation($"Обращение к методу получения продукта");
            var response = await productRepository.GetAllByWarehouseIdAsync(warehouseId);
            return new OperationResult<IEnumerable<ProductResponse>>(mapper.Map<IEnumerable<ProductResponse>>(response));
        }

        public async Task<OperationResult<bool>> IsExistProductAsync(int id)
        {
            logger.LogInformation($"Обращение к методу проверки существования продукта");
            var reponse = await productRepository.IsExistAsync(id);
            return new OperationResult<bool>(reponse);
        }

        public string GenerateQrCode(Product product)
        {
            var content = $"Name: {product.Name}\n" +
                $"Description: {product.Description}\n" +
                $"Category: {product.Category}\n" +
                $"Subcategory: {product.Subcategory}\n" +
                $"Quantity: {product.Count}\n" +
                $"Cost: {product.Cost}\n" +
                $"Accepted by an employee: {product.Staffer.PersonId}";
            
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode bitmapQRCode = new BitmapByteQRCode(qrCodeData);
            
            byte[] qrCodeBytes = bitmapQRCode.GetGraphic(20);
            string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);

            return qrCodeBase64;
        }
    }
}
