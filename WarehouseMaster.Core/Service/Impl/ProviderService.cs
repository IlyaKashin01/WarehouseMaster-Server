using AutoMapper;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Provider;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Service.Impl
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProviderService(IProviderRepository providerRepository, IMapper mapper)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> CreateProviderAsync(ProviderRequest request)
        {
            var provider = _mapper.Map<Provider>(request);
            var result = await _providerRepository.CreateAsync(provider);
            if (result != 0 ) return new OperationResult<int>(result);
            return OperationResult<int>.Fail(OperationCode.Error, "Ошибка сохранения данных поставщика");
        }

        public async Task<OperationResult<bool>> DeleteProviderAsync(int id)
        {
            var result = await _providerRepository.DeleteAsync(id);
            return new OperationResult<bool>(result);
        }

        public async Task<OperationResult<IEnumerable<ProviderResponse>>> GetAllProviderAsync()
        {
            var providers = await _providerRepository.GetAllAsync();
            return new OperationResult<IEnumerable<ProviderResponse>>(_mapper.Map<IEnumerable<ProviderResponse>>(providers));
        }

        public async Task<OperationResult<ProviderResponse>> GetProviderByIdAsync(int id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);
            return new OperationResult<ProviderResponse>(_mapper.Map<ProviderResponse>(provider));
        }

        public Task<OperationResult<bool>> IsExistProviderAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
