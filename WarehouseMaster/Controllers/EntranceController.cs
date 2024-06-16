using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Entrance;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.DTO.Provider;
using WarehouseMaster.Core.Service.Interfaces;

namespace WarehouseMaster.Controllers
{
    [Route("api/entrance")]
    [ApiController]
    public class EntranceController : ControllerBase
    {
        private readonly IEntranceService _entranceService;

        public EntranceController(IEntranceService entranceService)
        {
            _entranceService = entranceService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<OperationResult<IEnumerable<EntranceResponse>>>> GetAll(int warehouseId)
        {
            var response = await _entranceService.GetAllEntranceAsync(warehouseId);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<OperationResult<EntranceResponse>>> Get(int id)
        {
            var response = await _entranceService.GetEntranceByIdAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(EntranceRequest request)
        {
            var response = await _entranceService.CreateEntranceAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            var response = await _entranceService.DeleteEntranceAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
