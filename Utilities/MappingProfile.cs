using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.DTO.ResponseDTO;
using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDTO, IdentityUser>().ReverseMap();
            CreateMap<ErrorResponseDTO, Error>().ReverseMap();

            CreateMap<AssetTypeDTO, AssetType>().ReverseMap();
            CreateMap<AssetTypeUpdateDTO, AssetType>().ReverseMap();
            CreateMap<AssetTypeResponseDTO, AssetType>().ReverseMap();

            CreateMap<StateDTO, State>().ReverseMap();
            CreateMap<StateUpdateDTO, State>().ReverseMap();
            CreateMap<StateResponseDTO, State>().ReverseMap();

            CreateMap<AssetDTO, Asset>().ReverseMap();
            CreateMap<AssetUpdateDTO, Asset>().ReverseMap();
            CreateMap<AssetResponseDTO, Asset>().ReverseMap();

            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<OrderUpdateDTO, Order>().ReverseMap();
            CreateMap<OrderResponseDTO, Order>().ReverseMap();

        }
    }
}
