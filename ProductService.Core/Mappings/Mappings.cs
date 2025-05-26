using AutoMapper;
using WarehouseMaster.Common.DTO.Category;
using WarehouseMaster.Common.DTO.Product;
using WarehouseMaster.Common.DTO.SubCategory;
using WarehouseMaster.Domain.Entities;

namespace ProductService.Core.Mappings;

public class Mappings: Profile
{
    public Mappings()
    {
        CreateMap<CategoryRequest, Category>();
        CreateMap<Category, CategoryResponse>();

        CreateMap<SubCategoryRequest, SubCategory>();
        CreateMap<SubCategory, SubCategoryResponse>();

        CreateMap<ProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
    }
}