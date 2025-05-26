using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Services.Interfaces;
using WarehouseMaster.Common.DTO.Warehouse;
using WarehouseMaster.Common.OperationResult;

namespace Warehouse.API.Controllers
{
    [Route("api/warehouse")]
    [ApiController]
    public class WarehouseController(IWarehouseService warehouseService) : ControllerBase
    {
        [HttpGet("all")] public async Task<ActionResult<OperationResult<IEnumerable<WarehouseResponse>>>> GetAll()
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

        [HttpPut("{id}")]
        public Task<OperationResult<bool>> Get(WarehouseRequest request)
        {
            throw new NotImplementedException();
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
