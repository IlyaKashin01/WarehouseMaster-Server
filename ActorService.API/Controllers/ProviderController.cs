using ActorService.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.DTO.Product;
using WarehouseMaster.Common.DTO.Provider;
using WarehouseMaster.Common.OperationResult;

namespace ActorService.API.Controllers
{
    [Route("api/provider")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<OperationResult<IEnumerable<ProviderResponse>>>> GetAll()
        {
            var response = await _providerService.GetAllProviderAsync();
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<OperationResult<ProductResponse>>> Get(int id)
        {
            var response = await _providerService.GetProviderByIdAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Post(ProviderRequest request)
        {
            var response = await _providerService.CreateProviderAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            var response = await _providerService.DeleteProviderAsync(id);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
