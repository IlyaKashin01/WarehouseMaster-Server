using ActorService.Core.Services.Interfaces;
using ActorService.Data.Repositories.Interfaces;
using AutoMapper;
using WarehouseMaster.Common.DTO.Provider;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Domain.Entities;

namespace ActorService.Core.Services.Impl
{
    public class ProviderService(IProviderRepository providerRepository, IMapper mapper) : IProviderService
    {
        public async Task<OperationResult<int>> CreateProviderAsync(ProviderRequest request)
        {
            var provider = mapper.Map<Provider>(request);
            var result = await providerRepository.CreateAsync(provider);
            if (result != 0 ) return new OperationResult<int>(result);
            return OperationResult<int>.Fail(OperationCode.Error, "Ошибка сохранения данных поставщика");
        }

        public async Task<OperationResult<bool>> DeleteProviderAsync(int id)
        {
            var result = await providerRepository.DeleteAsync(id);
            return new OperationResult<bool>(result);
        }

        public async Task<OperationResult<IEnumerable<ProviderResponse>>> GetAllProviderAsync()
        {
            var providers = await providerRepository.GetAllAsync();
            return new OperationResult<IEnumerable<ProviderResponse>>(mapper.Map<IEnumerable<ProviderResponse>>(providers));
        }

        public async Task<OperationResult<ProviderResponse>> GetProviderByIdAsync(int id)
        {
            var provider = await providerRepository.GetByIdAsync(id);
            return new OperationResult<ProviderResponse>(mapper.Map<ProviderResponse>(provider));
        }

        public Task<OperationResult<bool>> IsExistProviderAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
