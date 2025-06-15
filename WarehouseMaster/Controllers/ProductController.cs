using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehouseMaster.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> Get(int id)
        {
            var response = await productService.GetProductByIdAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("all")]
        public async Task<ActionResult<OperationResult<ProductResponse>>> GetAll(int warehouseId)
        {
            var response = await productService.GetAllProductsByWarehouseAsync(warehouseId);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(ProductRequest request)
        {
            var response = await productService.CreateProductAsync(request);
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
            var response = await productService.DeleteProductAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
