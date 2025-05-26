using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Services.Interfaces;
using WarehouseMaster.Common.DTO.Shipment;
using WarehouseMaster.Common.OperationResult;

namespace Warehouse.API.Controllers
{
    [Route("api/shipment")]
    [ApiController]
    public class ShipmentController(IShipmentService shipmentService) : ControllerBase
    {
        [HttpGet("getAll")]
        public async Task<ActionResult<OperationResult<IEnumerable<ShipmentResponse>>>> GetAll(int warehouseId)
        {
            var response = await shipmentService.GetAllShipmentAsync(warehouseId);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<OperationResult<ShipmentRequest>>> Get(int id)
        {
            var response = await shipmentService.GetShipmentByIdAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(ShipmentRequest request)
        {
            var response = await shipmentService.CreateShipmentAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            var response = await shipmentService.DeleteShipmentAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
