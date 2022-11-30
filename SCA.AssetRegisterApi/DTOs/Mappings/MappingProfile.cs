using AutoMapper;
using SCA.AssetRegisterApi.Models;

namespace SCA.AssetRegisterApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AssetType, AssetTypeDTO>().ReverseMap();

        CreateMap<AssetDTO, Asset>();

        CreateMap<Asset, AssetDTO>()
           .ForMember(x => x.AssetTypeName, opt => opt.MapFrom(src => src.AssetType.Name));
    }
}
