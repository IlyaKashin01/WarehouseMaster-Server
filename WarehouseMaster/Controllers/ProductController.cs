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

        [HttpGet("get")]
        public Task<IEnumerable<ProductResponse>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("all")]
        public async Task<ActionResult<OperationResult<ProductResponse>>> Get(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(ProductRequest request)
        {
            var response = await _productService.CreateProductAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("update")]
        public Task<bool> Put(ProductRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            var response = await _productService.DeleteProductAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
