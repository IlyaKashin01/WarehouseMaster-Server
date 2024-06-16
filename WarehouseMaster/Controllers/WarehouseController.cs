using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Category;
using WarehouseMaster.Core.DTO.Warehouse;
using WarehouseMaster.Core.Service.Interfaces;

namespace WarehouseMaster.Controllers
{
    [Route("api/warehouse")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<OperationResult<IEnumerable<WarehouseResponse>>>> Get()
        {
            var response =  await _warehouseService.GetAllWarehousesAsync();
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(WarehouseRequest request)
        {
            var response =  await _warehouseService.CreateWarehouseAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public Task<OperationResult<bool>> Put(CategoryRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            var response = await _warehouseService.DeleteWarehouseAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
