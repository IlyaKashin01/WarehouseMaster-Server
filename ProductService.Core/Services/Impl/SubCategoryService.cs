using ActorService.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProductService.Core.Services.Interfaces;
using ProductService.Data.Repositories.Interfaces;
using WarehouseMaster.Common.DTO.SubCategory;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Domain.Entities;

namespace ProductService.Core.Services.Impl
{
    public class SubCategoryService(
        IMapper mapper,
        ILogger<SubCategoryService> logger,
        ISubCategoryRepository subCategoryRepository,
        ICategoryRepository categoryRepository,
        IStafferRepository stafferRepository)
        : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IStafferRepository _stafferRepository = stafferRepository;

        public async Task<OperationResult<int>> CreateSubCategoryAsync(SubCategoryRequest request)
        {
            if(await _categoryRepository.GetByNameAsync(request.NameCategory) == null)
            {
                logger.LogError("Попытка добавить подкатегорию в не существующую категорию");
                return OperationResult<int>.Fail(OperationCode.EntityWasNotFound, "добавление подкатегории в не существующую категорию");
            }
            if(await _subCategoryRepository.GetByNameAsync(request.Name) != null)
            {
                logger.LogError("Попытка добавить уже существующую подкатегорию");
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "подкатегория с таким названием уже существует");
            }
            logger.LogInformation($"Обращение к методу создания подкатегории");
            var subcategory = mapper.Map<SubCategory>(request);
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
            logger.LogInformation($"Обращение к методу удаления подкатегории");
            var response = await _stafferRepository.DeleteAsync(id);
            return new OperationResult<bool>(response);
        }

        public async Task<OperationResult<SubCategoryResponse>> GetSubCategoryByIdAsync(int id)
        {
            logger.LogInformation($"Обращение к методу получения подкатегории");
            var response = await _subCategoryRepository.GetByIdAsync(id);
            return new OperationResult<SubCategoryResponse>(mapper.Map<SubCategoryResponse>(response));
        }

        public async Task<OperationResult<bool>> IsExistSubCategoryAsync(int id)
        {
            logger.LogInformation($"Обращение к методу проверки существования подкатегории");
            var reponse = await _subCategoryRepository.IsExistAsync(id);
            return new OperationResult<bool>(reponse);
        }
    }
}
