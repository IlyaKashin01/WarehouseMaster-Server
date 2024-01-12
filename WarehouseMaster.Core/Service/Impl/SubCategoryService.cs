using AutoMapper;
using Microsoft.Extensions.Logging;
using WarehouseMaster.Core.DTO.SubCategory;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Service.Impl
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<SubCategoryService> _logger;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(IMapper mapper, ILogger<SubCategoryService> logger, ISubCategoryRepository subCategoryRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<int> CreateSubCategoryAsync(SubCategoryRequest request)
        {
            _logger.LogInformation($"Обращение к методу создания подкатегории для объекта: {request}");
            var subcategory = _mapper.Map<SubCategory>(request);
            return await _subCategoryRepository.CreateAsync(subcategory);
        }

        public Task<bool> DeleteSubCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategoryResponse> GetSubCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistSubCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
