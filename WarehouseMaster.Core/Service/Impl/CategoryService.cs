using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Category;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Service.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        private readonly ICategoryRepository _repository;

        public CategoryService(IMapper mapper, /*ILogger logger,*/ ICategoryRepository repository)
        {
            _mapper = mapper;
            //_logger = logger;
            _repository = repository;
        }

        public async Task<int> CreateCategoryAsync(CategoryRequest request)
        {
            //_logger.LogInformation($"Обращение к методу создания категории для объекта: {request}");
            var category = _mapper.Map<Category>(request);
            return await _repository.CreateAsync(category);
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
