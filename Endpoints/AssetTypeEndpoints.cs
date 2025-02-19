using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.DTO.ResponseDTO;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Filters;
using PPI_Challenge_API.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PPI_Challenge_API.Endpoints
{
    public static class AssetTypeEndpoints
    {
        public static RouteGroupBuilder MapAssetType(this RouteGroupBuilder group) 
        {
            group.MapGet("/", Get).RequireAuthorization();
            group.MapPost("/create", Create).AddEndpointFilter<ValidationFilter<AssetDTO>>().RequireAuthorization();
            group.MapPut("/update", Update).AddEndpointFilter<ValidationFilter<AssetUpdateDTO>>().RequireAuthorization();
            group.MapDelete("/delete", Delete).RequireAuthorization();
            group.MapGet("/getall", GetAll).RequireAuthorization();
            return group;
        }


        static async Task<Results<Ok<AssetTypeResponseDTO>, NoContent>> Get(int id, IMapper mapper, IAssetTypeRepository assetTypeRepository)
        {
            if (await assetTypeRepository.ExistsAsync(id.ToString()))
            {
                AssetType assetType = await assetTypeRepository.GetByIdAsync(id);
                var response = mapper.Map<AssetTypeResponseDTO>(assetType);
                return TypedResults.Ok(response);
            }
            return TypedResults.NoContent();
        }

        static async Task<Results<Created, BadRequest>> Create(AssetTypeDTO assetTypeDTO, IMapper mapper, IAssetTypeRepository assetTypeRepository)
        {
            if (!await assetTypeRepository.ExistsAsync(assetTypeDTO.Description))
            {
                var assetType = mapper.Map<AssetType>(assetTypeDTO);
                await assetTypeRepository.CreateAsync(assetType);
                return TypedResults.Created($"/assettypes/{assetType.Id}");
            }
            return TypedResults.BadRequest();
        }

        static async Task<Results<NoContent, BadRequest>> Update(AssetTypeUpdateDTO assetTypeUpdateDTO, IMapper mapper, IAssetTypeRepository assetTypeRepository)
        {
            if (await assetTypeRepository.ExistsAsync(assetTypeUpdateDTO.Id))
            {
                var assetType = await assetTypeRepository.GetByIdAsync(assetTypeUpdateDTO.Id);
                assetType = mapper.Map(assetTypeUpdateDTO, assetType);
                await assetTypeRepository.UpdateAsync(assetType);
                return TypedResults.NoContent();
            }
            return TypedResults.BadRequest();
        }

        static async Task<NoContent> Delete(int id, IAssetTypeRepository assetTypeRepository)
        {
            if (await assetTypeRepository.ExistsAsync(id))
            {
                await assetTypeRepository.DeleteAsync(id);
            }

            return TypedResults.NoContent();
        }

        static async Task<Results<Ok<List<AssetTypeResponseDTO>>, NoContent>> GetAll(IAssetTypeRepository assetTypeRepository, IMapper mapper)
        {
            var assetTypes = await assetTypeRepository.GetAllAsync();
            if (assetTypes.Count() > 0)
            {
                var response = mapper.Map<List<AssetTypeResponseDTO>>(assetTypes);
                return TypedResults.Ok(response);
            }
            return TypedResults.NoContent();

        }
    }
}
