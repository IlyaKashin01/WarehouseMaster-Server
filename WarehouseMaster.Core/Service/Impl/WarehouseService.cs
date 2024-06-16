using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Warehouse;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Service.Impl
{
    public class WarehouseService(IWarehouseRepository warehouseRepository, IMapper mapper) : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository = warehouseRepository;
        private readonly IMapper _mapper = mapper;


        public async Task<OperationResult<int>> CreateWarehouseAsync(WarehouseRequest request)
        {
            if (await _warehouseRepository.GetWarehouseByNameAsync(request.Name) != null)
            {
                return OperationResult<int>.Fail(OperationCode.AlreadyExists, "Склад уже существует");
            }
            else
            {
                var entity = _mapper.Map<Warehouse>(request);
                var warehouseId = await _warehouseRepository.CreateAsync(entity);
                return new OperationResult<int>(warehouseId);
            }
        }

        public async Task<OperationResult<bool>> DeleteWarehouseAsync(int id)
        {
            if (await _warehouseRepository.GetByIdAsync(id) == null)
            {
                return OperationResult<bool>.Fail(OperationCode.AlreadyExists, "Склада не существует");
            }
            else
            {
                var status = await _warehouseRepository.DeleteAsync(id);
                if (status) return new OperationResult<bool>(true);
                else return OperationResult<bool>.Fail(OperationCode.AlreadyExists, "Ошибка при удалении");
            }
        }

        public async Task<OperationResult<IEnumerable<WarehouseResponse>>> GetAllWarehousesAsync()
        {
            var warehouses = await _warehouseRepository.GetAllWarehousesAsync();
            var response =  _mapper.Map<IEnumerable<WarehouseResponse>>(warehouses);
            return new OperationResult<IEnumerable<WarehouseResponse>>(response);
        }
    }
}
