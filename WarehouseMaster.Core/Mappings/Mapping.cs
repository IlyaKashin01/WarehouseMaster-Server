using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Category;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.DTO.Staffer;
using WarehouseMaster.Core.DTO.SubCategory;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Mappings
{
    public class Mapping: Profile
    {
        public Mapping() 
        {
            CreateMap<StafferRequest, Staffer>();
            CreateMap<Staffer, StafferResponse>();

            CreateMap<CategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();

            CreateMap<SubCategoryRequest, SubCategory>();
            CreateMap<SubCategory, SubCategoryResponse>();

            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
