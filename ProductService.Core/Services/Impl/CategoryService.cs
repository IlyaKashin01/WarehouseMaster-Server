using ActorService.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProductService.Core.Services.Interfaces;
using ProductService.Data.Repositories.Interfaces;
using WarehouseMaster.Common.DTO.Category;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Domain.Entities;

namespace ProductService.Core.Services.Impl
{
    public class CategoryService(
        IMapper mapper,
        ILogger<CategoryService> logger,
        ICategoryRepository repository,
        IStafferRepository stafferRepository)
        : ICategoryService
    {
        public async Task<OperationResult<int>> CreateCategoryAsync(CategoryRequest request)
        {
            if(await repository.GetByNameAsync(request.Name) != null)
            {
                logger.LogError($"Попытка создания уже существующей категории");
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "Категория с таким названием уже существует");
            }
            logger.LogInformation($"Обращение к методу создания категории");
            var category = mapper.Map<Category>(request);
            var staffer = await stafferRepository.GetByIdAsync(request.StafferId);
            if(staffer != null)
                category.Staffer = staffer;
            var response = await repository.CreateAsync(category);
            return new OperationResult<int>(response);
        }

        public async Task<OperationResult<bool>> DeleteCategoryAsync(int id)
        {
            logger.LogInformation($"Обращение к методу удаления категории");
            var response = await repository.DeleteAsync(id);
            return new OperationResult<bool>(response);
        }

        public async Task<OperationResult<CategoryResponse>> GetCategoryByIdAsync(int id)
        {
            logger.LogInformation($"Обращение к методу получения категории по id");
            var response = await repository.GetByIdAsync(id);
            return new OperationResult<CategoryResponse>(mapper.Map<CategoryResponse>(response));
        }

        public async Task<OperationResult<bool>> IsExistCategoryAsync(int id)
        {
            logger.LogInformation($"Обращение к методу проверки существования категории");
            var response = await repository.IsExistAsync(id);
            return new OperationResult<bool>(response);
        }
    }
}
