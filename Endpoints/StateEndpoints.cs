using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.DTO.ResponseDTO;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Filters;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Endpoints
{
    public static class StateEndpoints
    {

        public static RouteGroupBuilder MapState(this RouteGroupBuilder group)
        {
            group.MapGet("/", Get).RequireAuthorization();
            group.MapPost("/create", Create).AddEndpointFilter<ValidationFilter<StateDTO>>().RequireAuthorization();
            group.MapPut("/update", Update).AddEndpointFilter<ValidationFilter<StateUpdateDTO>>().RequireAuthorization();
            group.MapDelete("/delete", Delete).RequireAuthorization();
            group.MapGet("/getall", GetAll).RequireAuthorization();
            return group;
        }


        static async Task<Results<Ok<StateResponseDTO>, NoContent>> Get(int id, IMapper mapper, IStateRepository StateRepository)
        {
            if (await StateRepository.ExistsAsync(id))
            {
                State state = await StateRepository.GetByIdAsync(id);
                var response = mapper.Map<StateResponseDTO>(state);
                return TypedResults.Ok(response);
            }
            return TypedResults.NoContent();
        }

        static async Task<Results<Created, BadRequest>> Create(StateDTO StateDTO, IMapper mapper, IStateRepository stateRepository)
        {
            if (!await stateRepository.ExistsAsync(StateDTO.Description))
            {
                var state = mapper.Map<State>(StateDTO);
                await stateRepository.CreateAsync(state);
                return TypedResults.Created($"/States/{state.Id}");
            }
            return TypedResults.BadRequest();
        }

        static async Task<Results<NoContent, BadRequest>> Update(StateUpdateDTO stateUpdateDTO, IMapper mapper, IStateRepository stateRepository)
        {
            if (await stateRepository.ExistsAsync(stateUpdateDTO.Id))
            {
                var State = await stateRepository.GetByIdAsync(stateUpdateDTO.Id);
                State = mapper.Map(stateUpdateDTO, State);
                await stateRepository.UpdateAsync(State);
                return TypedResults.NoContent();
            }
            return TypedResults.BadRequest();
        }

        static async Task<NoContent> Delete(int id, IStateRepository stateRepository)
        {
            if (await stateRepository.ExistsAsync(id))
            {
                await stateRepository.DeleteAsync(id);
            }

            return TypedResults.NoContent();
        }

        static async Task<Results<Ok<List<StateResponseDTO>>, NoContent>> GetAll(IStateRepository stateRepository, IMapper mapper)
        {
            var states = await stateRepository.GetAllAsync();
            if (states.Count() > 0)
            {
                var response = mapper.Map<List<StateResponseDTO>>(states);
                return TypedResults.Ok(response);
            }
            return TypedResults.NoContent();

        }
    }
}
