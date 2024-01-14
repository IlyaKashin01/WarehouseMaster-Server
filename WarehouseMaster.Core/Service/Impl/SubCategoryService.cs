using AutoMapper;
using Microsoft.Extensions.Logging;
using WarehouseMaster.Common.OperationResult;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStafferRepository _stafferRepository;

        public SubCategoryService(IMapper mapper, ILogger<SubCategoryService> logger, ISubCategoryRepository subCategoryRepository, ICategoryRepository categoryRepository, IStafferRepository stafferRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _subCategoryRepository = subCategoryRepository;
            _categoryRepository = categoryRepository;
            _stafferRepository = stafferRepository;
        }

        public async Task<OperationResult<int>> CreateSubCategoryAsync(SubCategoryRequest request)
        {
            if(await _categoryRepository.GetByNameAsync(request.NameCategory) == null)
            {
                _logger.LogError("Попытка добавить подкатегорию в не существующую категорию");
                return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "добавление подкатегории в не существующую категорию");
            }
            if(await _subCategoryRepository.GetByNameAsync(request.Name) != null)
            {
                _logger.LogError("Попытка добавить уже существующую подкатегорию");
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "подкатегория с таким названием уже существует");
            }
            _logger.LogInformation($"Обращение к методу создания подкатегории");
            var subcategory = _mapper.Map<SubCategory>(request);
            var category = await _categoryRepository.GetByNameAsync(request.NameCategory);
            var staffer = await _stafferRepository.GetByIdAsync(request.StafferId);
            if (category != null && staffer != null)
            {
                subcategory.Category = category;
                subcategory.Staffer = staffer;
            }
            var response = await _subCategoryRepository.CreateAsync(subcategory);
            return new OperationResult<int>(response);
        }

        public async Task<OperationResult<bool>> DeleteSubCategoryAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу удаления подкатегории");
            var response = await _stafferRepository.DeleteAsync(id);
            return new OperationResult<bool>(response);
        }

        public async Task<OperationResult<SubCategoryResponse>> GetSubCategoryByIdAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу получения подкатегории");
            var response = await _subCategoryRepository.GetByIdAsync(id);
            return new OperationResult<SubCategoryResponse>(_mapper.Map<SubCategoryResponse>(response));
        }

        public async Task<OperationResult<bool>> IsExistSubCategoryAsync(int id)
        {
            _logger.LogInformation($"Обращение к методу проверки существования подкатегории");
            var reponse = await _subCategoryRepository.IsExistAsync(id);
            return new OperationResult<bool>(reponse);
        }
    }
}
