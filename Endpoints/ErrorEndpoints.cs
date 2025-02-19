using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PPI_Challenge_API.DTO.ResponseDTO;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Repositories.Interfaces;
using PPI_Challenge_API.Utilities;
using System.ComponentModel;

namespace PPI_Challenge_API.Endpoints
{
    public static class ErrorEndpoints
    {
        public static RouteGroupBuilder  MapErrors(this RouteGroupBuilder group) 
        {
            group.MapGet("getAll", GetAll).RequireAuthorization(PolicyUtilities.AdminPolicy);
            return group;
        }

        static async Task<Results<Ok<List<ErrorResponseDTO>>,NoContent>> GetAll(IConfiguration configuration, IMapper mapper, IErrorsRepository errorsRepository)
        {
            List<Error> errors = await errorsRepository.GetAllAsync();
            if (errors.Count >= 0)
            {
                var response = mapper.Map<List<ErrorResponseDTO>>(errors);
                return TypedResults.Ok(response);
            }
            return TypedResults.NoContent();
        }

    }
}
