using AutoMapper;
using WarehouseMaster.Common.DTO.Provider;
using WarehouseMaster.Common.DTO.Staffer;
using WarehouseMaster.Domain.Entities;

namespace ActorService.Core.Mappings;

public class Mappings: Profile
{
    public Mappings()
    {
        CreateMap<StafferRequest, Staffer>();
        CreateMap<Staffer, StafferResponse>();

        CreateMap<StafferRequest, Person>();
        
        CreateMap<ProviderRequest, Provider>();
        CreateMap<Provider, ProviderResponse>();
    }
}