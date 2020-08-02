using API.DTO.Contract;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class ContractMappingProfile : Profile
    {
        public ContractMappingProfile()
        {
            CreateMap<ProductForAddDTO, Product>();
            CreateMap<ProductForEditDTO, Product>();

            CreateMap<Product, ProductForGetDTO>()
                      .ForMember(dest => dest.Path, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.FileName) ? $"Contract/{src.Id}/{src.FileName}" : null));
        }
    }
}
