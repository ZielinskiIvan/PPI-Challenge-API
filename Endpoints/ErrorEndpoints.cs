using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PPI_Challenge_API.DTO.ResponseDTO;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Services.Interfaces;
using System.ComponentModel;

namespace PPI_Challenge_API.Endpoints
{
    public static class ErrorEndpoints
    {
        public static RouteGroupBuilder  MapErrors(this RouteGroupBuilder group) 
        {
            group.MapGet("GetAll", GetAll).RequireAuthorization();
            return group;
        }

        static async Task<Results<Ok<List<ErrorDTOResponse>>,NoContent>> GetAll(IConfiguration configuration, IMapper mapper, IErrorsRepository errorsRepository)
        {

            List<Error> errors = await errorsRepository.GetAllAsync();
            if (errors.Count >= 0)
            {
                var response = mapper.Map<List<ErrorDTOResponse>>(errors);
                return TypedResults.Ok(response);
            }
            return TypedResults.NoContent();
        }

    }
}
