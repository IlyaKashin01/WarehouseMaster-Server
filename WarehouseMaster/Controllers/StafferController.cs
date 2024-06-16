using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Staffer;
using WarehouseMaster.Core.Service.Interfaces;

namespace WarehouseMaster.Controllers
{
    [Route("api/staffer")]
    [ApiController]
    public class StafferController : ControllerBase
    {
        private readonly IStafferService _stafferService;

        public StafferController(IStafferService stafferService)
        {
            _stafferService = stafferService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<OperationResult<IEnumerable<StafferResponse>>>> Get()
        {
            var response =  await _stafferService.GetAllStaffersAsync();
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<OperationResult<StafferResponse>>> Get(int id)
        {
            var response = await _stafferService.GetStafferByIdAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(StafferRequest request)
        {
            var response = await _stafferService.CreateStafferAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public Task<OperationResult<bool>> Put(StafferRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            var response =  await _stafferService.DeleteStafferAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
