using AutoMapper;
using WarehouseMaster.Common.DTO.Entrance;
using WarehouseMaster.Common.DTO.Shipment;
using WarehouseMaster.Common.DTO.Warehouse;
using WarehouseMaster.Domain.Entities;

namespace Warehouse.Core.Mappings;

public class Mappings: Profile
{
    public Mappings()
    {
        CreateMap<EntranceRequest, Entrance>();
        CreateMap<Entrance, EntranceResponse>();

        CreateMap<ShipmentRequest, Shipment>();
        CreateMap<Shipment, ShipmentResponse>();

        CreateMap<WarehouseRequest, WarehouseMaster.Domain.Entities.Warehouse>();
        CreateMap<WarehouseMaster.Domain.Entities.Warehouse, WarehouseResponse>();
    }
}