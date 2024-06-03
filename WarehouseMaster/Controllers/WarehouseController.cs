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

        [HttpGet]
        public async Task<OperationResult<IEnumerable<WarehouseResponse>>> Get()
        {
            return await _warehouseService.GetAllWarehousesAsync();
        }

        [HttpPost]
        public async Task<OperationResult<int>> Post(WarehouseRequest request)
        {
            return await _warehouseService.CreateWarehouseAsync(request);
        }

        [HttpPut("{id}")]
        public Task<OperationResult<bool>> Put(CategoryRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<OperationResult<bool>> Delete(int id)
        {
            return await _warehouseService.DeleteWarehouseAsync(id);
        }
    }
}
