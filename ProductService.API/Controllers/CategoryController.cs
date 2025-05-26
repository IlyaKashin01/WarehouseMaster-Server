using Microsoft.AspNetCore.Mvc;
using ProductService.Core.Services.Interfaces;
using WarehouseMaster.Common.DTO.Category;
using WarehouseMaster.Common.OperationResult;

namespace ProductService.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public Task<IEnumerable<CategoryResponse>> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<OperationResult<CategoryResponse>> Get(int id)
        {
            return await _categoryService.GetCategoryByIdAsync(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<OperationResult<int>> Post(CategoryRequest request)
        {
            return await _categoryService.CreateCategoryAsync(request);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public Task<OperationResult<bool>> Put(CategoryRequest request)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<OperationResult<bool>> Delete(int id)
        {
            return await _categoryService.DeleteCategoryAsync(id);
        }
    }
}
