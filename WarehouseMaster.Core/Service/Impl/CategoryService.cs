using AutoMapper;
using Microsoft.Extensions.Logging;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Category;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Service.Impl
{
    public class CategoryService : ICategoryService 
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStafferRepository _stafferRepository;

        public CategoryService(IMapper mapper, ILogger<CategoryService> logger, ICategoryRepository repository, IStafferRepository stafferRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _categoryRepository = repository;
            _stafferRepository = stafferRepository;
        }

        public async Task<OperationResult<int>> CreateCategoryAsync(CategoryRequest request)
        {
            if(await _categoryRepository.GetByNameAsync(request.Name) != null)
            {
                _logger.LogError($"Попытка создания уже существующей категории");
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "Категория с таким названием уже существует");
            }
            _logger.LogInformation($"Обращение к методу создания категории");
            var category = _mapper.Map<Category>(request);
            var staffer = await _stafferRepository.GetByIdAsync(request.StafferId);
            if(staffer != null)
                category.Staffer = staffer;
            var response = await _categoryRepository.CreateAsync(category);
            return new OperationResult<int>(response);
        }

        public async Task<OperationResult<bool>> DeleteCategoryAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу удаления категории");
            var response = await _categoryRepository.DeleteAsync(id);
            return new OperationResult<bool>(response);
        }

        public async Task<OperationResult<CategoryResponse>> GetCategoryByIdAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу получения категории по id");
            var response = await _categoryRepository.GetByIdAsync(id);
            return new OperationResult<CategoryResponse>(_mapper.Map<CategoryResponse>(response));
        }

        public async Task<OperationResult<bool>> IsExistCategoryAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу проверки существования категории");
            var response = await _categoryRepository.IsExistAsync(id);
            return new OperationResult<bool>(response);
        }
    }
}
