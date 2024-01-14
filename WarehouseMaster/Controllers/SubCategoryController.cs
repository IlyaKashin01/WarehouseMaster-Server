using Microsoft.AspNetCore.Mvc;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.SubCategory;
using WarehouseMaster.Core.Service.Interfaces;

namespace WarehouseMaster.Controllers
{
    [Route("api/subcategory")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        // GET: api/<SubCategoryController>
        [HttpGet]
        public Task<OperationResult<IEnumerable<SubCategoryResponse>>> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<SubCategoryController>/5
        [HttpGet("{id}")]
        public async Task<OperationResult<SubCategoryResponse>> Get(int id)
        {
            return await _subCategoryService.GetSubCategoryByIdAsync(id);
        }

        // POST api/<SubCategoryController>
        [HttpPost]
        public async Task<OperationResult<int>> Post(SubCategoryRequest request)
        {
            return await _subCategoryService.CreateSubCategoryAsync(request);
        }

        // PUT api/<SubCategoryController>/5
        [HttpPut("{id}")]
        public Task<OperationResult<bool>> Put(SubCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<SubCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<OperationResult<bool>> Delete(int id)
        {
            return await _subCategoryService.DeleteSubCategoryAsync(id);
        }
    }
}
