using App.Api.ViewModels.Response;
using App.BusinessLayer.Entities;
using AutoMapper;

namespace App.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ForMember(dest => dest.RegisterDate, opt => opt.MapFrom(src => src.RegisteredAt));
            CreateMap<Product , ProductViewModel>().ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));
        
        }
    }
}
