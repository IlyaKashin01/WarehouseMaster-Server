using Microsoft.AspNetCore.Mvc;
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

        // GET: api/<StafferController>
        [HttpGet]
        public Task<IEnumerable<StafferResponse>> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<StafferController>/5
        [HttpGet("{id}")]
        public async Task<StafferResponse> Get(int id)
        {
            return await _stafferService.GetStafferByIdAsync(id);
        }

        // POST api/<StafferController>
        [HttpPost]
        public async Task<int> Post(StafferRequest request)
        {
            return await _stafferService.CreateStafferAsync(request);
        }

        // PUT api/<StafferController>/5
        [HttpPut("{id}")]
        public Task<bool> Put(StafferRequest request)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<StafferController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _stafferService.DeleteStafferAsync(id);
        }
    }
}
