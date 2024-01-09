using AutoMapper;
using Microsoft.Extensions.Logging;
using QRCoder;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;

namespace WarehouseMaster.Core.Service.Impl
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository /*, ILogger logger*/)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            //_logger = logger;
        }

        public async Task<int> CreateProductAsync(ProductRequest request)
        {
            //_logger.LogInformation($"Обращение к методу создания продукта для объекта: {request}");
            var product = _mapper.Map<Product>(request);
            product.QRCode = GenerateQrCode(product); 
            return await _productRepository.CreateAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            //_logger.LogInformation($"Обращение к методу удаления продукта с id: {id}");
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            //_logger.LogInformation($"Обращение к методу получения продукта по id: {id}");
            var response = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductResponse>(response);
        }

        public async Task<bool> IsExistProductAsync(int id)
        {
            //_logger.LogInformation($"Обращение к методу проверки существования продукта с id: {id}");
            return await _productRepository.IsExistAsync(id);
        }

        public string GenerateQrCode(Product product)
        {
            var content = $"Name: {product.Name}\n" +
                $"Description: {product.Description}\n" +
                $"Category: {product.CategoryId}\n" +
                $"Subcategory: {product.SubcategoryId}\n" +
                $"Quantity: {product.Count}\n" +
                $"Cost: {product.Cost}";
            
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode bitmapQRCode = new BitmapByteQRCode(qrCodeData);
            
            byte[] qrCodeBytes = bitmapQRCode.GetGraphic(20);
            string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);

            return qrCodeBase64;
        }
    }
}
