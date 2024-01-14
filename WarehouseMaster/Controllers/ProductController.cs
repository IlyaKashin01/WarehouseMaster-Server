using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehouseMaster.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public Task<IEnumerable<ProductResponse>> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<OperationResult<ProductResponse>> Get(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<OperationResult<int>> Post(ProductRequest request)
        {
            return await _productService.CreateProductAsync(request);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public Task<bool> Put(ProductRequest request)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<OperationResult<bool>> Delete(int id)
        {
            return await _productService.DeleteProductAsync(id);
        }
    }
}
