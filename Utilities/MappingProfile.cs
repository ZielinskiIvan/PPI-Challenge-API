using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PPI_Challenge_API.DTO.RequestDTO;

namespace PPI_Challenge_API.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Ejemplo de mapeo entre un DTO y un modelo
            CreateMap<UserCredentialsDTO, IdentityUser>().ReverseMap();
        }
    }
}
