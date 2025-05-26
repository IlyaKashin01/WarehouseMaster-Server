using ActorService.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProductService.Core.Services.Interfaces;
using ProductService.Data.Repositories.Interfaces;
using QRCoder;
using WarehouseMaster.Common.DTO.Product;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Domain.Entities;
using WarehouseService.Data.Repositories.Interfaces;

namespace ProductService.Core.Services.Impl
{
    public class ProductService(
        IMapper mapper,
        IProductRepository productRepository,
        ILogger<ProductService> logger,
        ICategoryRepository categoryRepository,
        ISubCategoryRepository subCategoryRepository,
        IStafferRepository stafferRepository,
        IWarehouseRepository warehouseRepository)
        : IProductService
    {
        private readonly IWarehouseRepository _warehouseRepository = warehouseRepository;
        private readonly IStafferRepository _stafferRepository = stafferRepository;

        public async Task<OperationResult<int>> CreateProductAsync(ProductRequest request)
        {
            logger.LogInformation($"Обращение к методу создания продукта");
            var product = mapper.Map<Product>(request);
            var category = await categoryRepository.GetByNameAsync(request.NameCategory);
            var staffer = await _stafferRepository.GetByIdAsync(product.StafferId);
            var warehouse = await _warehouseRepository.GetByIdAsync(request.WarehouseId);
            if (category != null && staffer != null && warehouse != null)
            {
                product.Category = category;
                product.Staffer = staffer;
                product.Warehouse = warehouse;
            }
            else {
                logger.LogError("Попытка добавления товара без указания категории или сотрудника");
                return OperationResult<int>.Fail(OperationCode.ValidationError, "для добавления продукта необходимо указать категорию и сотрудника");
            }
            if (request.NameSubCategory != null)
            {
                var subCategory = await subCategoryRepository.GetByNameAsync(request.NameSubCategory);
                if (subCategory != null)
                    product.Subcategory = subCategory;
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
                $"Category: {product.Category.Name}\n" +
                $"Subcategory: {product.Subcategory.Name}\n" +
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
