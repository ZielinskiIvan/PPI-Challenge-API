using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.DTO.ResponseDTO;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Filters;
using PPI_Challenge_API.Services.Implementations;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Endpoints
{
    public static class OrderEndpoints
    {
        public static RouteGroupBuilder MapOrders(this RouteGroupBuilder group)
        {
            group.MapGet("/", Get).RequireAuthorization();
            group.MapPost("/create", Create).RequireAuthorization();
            group.MapPut("/update", Update).AddEndpointFilter<ValidationFilter<AssetUpdateDTO>>().RequireAuthorization();
            group.MapDelete("/delete", Delete).RequireAuthorization();
            group.MapGet("/getall", GetAll).RequireAuthorization();
            return group;
        }
        static async Task<Results<Ok<OrderResponseDTO>, NoContent>> Get(int id, IMapper mapper, IOrderRepository orderRepository)
        {
            if (await orderRepository.ExistsAsync(id))
            {
                Order order = await orderRepository.GetByIdAsync(id);
                var response = mapper.Map<OrderResponseDTO>(order);
                return TypedResults.Ok(response);
            }
            return TypedResults.NoContent();
        }

        static async Task<Results<Created, BadRequest>> Create(OrderDTO orderDTO, IMapper mapper,
            IOrderRepository orderRepository,
            IAssetRepository assetRepository,
            IStateRepository stateRepository,
            IUsersService usersService,
            IAssetHandler assetHandler)
        {

            var user = await usersService.GetUser();

            Asset asset = await assetRepository.GetByIdAsync(orderDTO.AssetID);

            if (asset is not null && await stateRepository.ExistsAsync(orderDTO.StateID))
            {
                IAssetAmountCalculator calculator = await assetHandler.GetCalculator(asset.AssetTypeID);

                var order = mapper.Map<Order>(orderDTO);
                order.UserID = user.Id;
                order.TotalAmount = await calculator.GetTotalAmountAsync(orderDTO.Quantity,asset,orderDTO.Price);
                await assetRepository.CreateAsync(asset);
                return TypedResults.Created($"/States/{asset.Id}");
            }
            return TypedResults.BadRequest();
        }

        static async Task<Results<NoContent, BadRequest>> Update(AssetUpdateDTO assetUpdateDTO, IMapper mapper, IAssetRepository assetRepository, IAssetTypeRepository assetTypeRepository)
        {
            if (await assetRepository.ExistsAsync(assetUpdateDTO.Id) && await assetTypeRepository.ExistsAsync(assetUpdateDTO.AssetTypeID))
            {
                var State = await assetRepository.GetByIdAsync(assetUpdateDTO.Id);
                State = mapper.Map(assetUpdateDTO, State);
                await assetRepository.UpdateAsync(State);
                return TypedResults.NoContent();
            }
            return TypedResults.BadRequest();
        }

        static async Task<NoContent> Delete(int id, IAssetRepository assetRepository)
        {
            if (await assetRepository.ExistsAsync(id))
            {
                await assetRepository.DeleteAsync(id);
            }

            return TypedResults.NoContent();
        }

        static async Task<Results<Ok<List<AssetResponseDTO>>, NoContent>> GetAll(IAssetRepository assetRepository, IMapper mapper)
        {
            var states = await assetRepository.GetAllAsync();
            if (states.Count() > 0)
            {
                var response = mapper.Map<List<AssetResponseDTO>>(states);
                return TypedResults.Ok(response);
            }
            return TypedResults.NoContent();

        }
    }
}
