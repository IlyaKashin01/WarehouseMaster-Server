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
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IStafferRepository _stafferRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository, ILogger<ProductService> logger, ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository, IStafferRepository stafferRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _logger = logger;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _stafferRepository = stafferRepository;
        }

        public async Task<OperationResult<int>> CreateProductAsync(ProductRequest request)
        {
            _logger.LogInformation($"Обращение к методу создания продукта");
            var product = _mapper.Map<Product>(request);
            var category = await _categoryRepository.GetByNameAsync(request.NameCategory);
            var staffer = await _stafferRepository.GetByIdAsync(product.StafferId);
            if (category != null && staffer != null)
            {
                product.Category = category;
                product.Staffer = staffer;
            }
            else {
                _logger.LogError("Попытка добавления товара без указания категории или сотрудника");
                return OperationResult<int>.Fail(OperationCode.ValidationError, "для добавления продукта необходимо указать категорию и сотрудника");
            }
            if (request.NameSubCategory != null)
            {
                var subCategory = await _subCategoryRepository.GetByNameAsync(request.NameSubCategory);
                if (subCategory != null)
                    product.Subcategory = subCategory;
            }
            product.QRCode = GenerateQrCode(product);
            var response = await _productRepository.CreateAsync(product);
            return new OperationResult<int>(response);
        }

        public async Task<OperationResult<bool>> DeleteProductAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу удаления продукта");
            var reponse = await _productRepository.DeleteAsync(id);
            return new OperationResult<bool>(reponse);
        }

        public async Task<OperationResult<ProductResponse>> GetProductByIdAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу получения продукта");
            var response = await _productRepository.GetByIdAsync(id);
            return new OperationResult<ProductResponse>(_mapper.Map<ProductResponse>(response));
        }

        public async Task<OperationResult<bool>> IsExistProductAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу проверки существования продукта");
            var reponse = await _productRepository.IsExistAsync(id);
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
