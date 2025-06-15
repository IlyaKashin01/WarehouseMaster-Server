using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Category;
using WarehouseMaster.Core.DTO.Warehouse;
using WarehouseMaster.Core.Service.Interfaces;

namespace WarehouseMaster.Controllers
{
    [Route("api/warehouse")]
    [ApiController]
    public class WarehouseController(IWarehouseService warehouseService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<ActionResult<OperationResult<IEnumerable<WarehouseResponse>>>> GetAll()
        {
            var response =  await warehouseService.GetAllWarehousesAsync();
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(WarehouseRequest request)
        {
            var response =  await warehouseService.CreateWarehouseAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OperationResult<WarehouseResponse>>> Get(int id)
        {
            var response = await warehouseService.GetWarehouseByIdAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            var response = await warehouseService.DeleteWarehouseAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
