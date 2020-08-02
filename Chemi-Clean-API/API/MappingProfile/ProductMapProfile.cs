using API.DTO.Product;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class ContractMappingProfile : Profile
    {
        public ContractMappingProfile()
        {           
            CreateMap<Product, ProductForGetDTO>()
                      .ForMember(dest => dest.Path, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.LocalUrl) ? src.LocalUrl : src.Url));
        }
    }
}
