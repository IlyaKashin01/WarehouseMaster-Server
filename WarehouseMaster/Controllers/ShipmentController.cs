using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Entrance;
using WarehouseMaster.Core.DTO.Shipment;
using WarehouseMaster.Core.Service.Interfaces;

namespace WarehouseMaster.Controllers
{
    [Route("api/shipment")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<OperationResult<IEnumerable<ShipmentResponse>>>> GetAll(int warehouseId)
        {
            var response = await _shipmentService.GetAllShipmentAsync(warehouseId);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<OperationResult<ShipmentRequest>>> Get(int id)
        {
            var response = await _shipmentService.GetShipmentByIdAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(ShipmentRequest request)
        {
            var response = await _shipmentService.CreateShipmentAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            var response = await _shipmentService.DeleteShipmentAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
