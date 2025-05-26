using ActorService.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.DTO.Staffer;
using WarehouseMaster.Common.OperationResult;

namespace ActorService.API.Controllers
{
    [Route("api/staffer")]
    [ApiController]
    public class StafferController(IStafferService stafferService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<ActionResult<OperationResult<IEnumerable<StafferResponse>>>> Get()
        {
            var response =  await stafferService.GetAllStaffersAsync();
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<OperationResult<StafferResponse>>> Get(int id)
        {
            var response = await stafferService.GetStafferByIdAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(StafferRequest request)
        {
            var response = await stafferService.CreateStafferAsync(request);
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
            var response =  await stafferService.DeleteStafferAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
