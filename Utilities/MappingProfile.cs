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
            // Ejemplo de mapeo entre un DTO y un modelo
            CreateMap<UserRegisterDTO, IdentityUser>().ReverseMap();
            CreateMap<ErrorDTOResponse, Error>().ReverseMap();
        }
    }
}
