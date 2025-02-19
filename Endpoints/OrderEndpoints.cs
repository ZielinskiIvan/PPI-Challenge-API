using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.DTO.ResponseDTO;
using PPI_Challenge_API.Entities;
using PPI_Challenge_API.Filters;
using PPI_Challenge_API.Repositories.Interfaces;
using PPI_Challenge_API.Services.Implementations;
using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Endpoints
{
    public static class OrderEndpoints
    {
        public static RouteGroupBuilder MapOrders(this RouteGroupBuilder group)
        {
            group.MapGet("/", Get).RequireAuthorization();
            group.MapPost("/create", Create).AddEndpointFilter<ValidationFilter<OrderDTO>>().RequireAuthorization();
            group.MapPut("/update", Update).RequireAuthorization();
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
            IUsersService usersService,
            IAssetHandler assetHandler)
        {

            var user = await usersService.GetUser();

            Asset asset = await assetRepository.GetByIdAsync(orderDTO.AssetID);

            if (asset is not null)
            {
                IAssetAmountCalculator calculator = await assetHandler.GetCalculator(asset.AssetTypeID);

                var order = mapper.Map<Order>(orderDTO);
                order.UserID = user.Id;
                order.TotalAmount = await calculator.GetTotalAmountAsync(orderDTO.Quantity,asset,orderDTO.Price);
                await orderRepository.CreateAsync(order);
                return TypedResults.Created($"/States/{order.Id}");
            }
            return TypedResults.BadRequest();
        }

        static async Task<Results<NoContent, BadRequest>> Update(OrderUpdateDTO orderUpdateDTO, 
            IMapper mapper, 
            IStateRepository stateRepository, 
            IOrderRepository orderRepository)
        {
            if (await orderRepository.ExistsAsync(orderUpdateDTO.OrderId) && await stateRepository.ExistsAsync(orderUpdateDTO.StateId))
            {
                var order = await orderRepository.GetByIdAsync(orderUpdateDTO.OrderId);
                order = mapper.Map(orderUpdateDTO, order);
                await orderRepository.UpdateAsync(order);
                return TypedResults.NoContent();
            }
            return TypedResults.BadRequest();
        }

        static async Task<NoContent> Delete(int id, IOrderRepository orderRepository)
        {
            if (await orderRepository.ExistsAsync(id))
            {
                await orderRepository.DeleteAsync(id);
            }

            return TypedResults.NoContent();
        }

        static async Task<Results<Ok<List<OrderResponseDTO>>, NoContent>> GetAll(IOrderRepository orderRepository, IMapper mapper)
        {
            var orders = await orderRepository.GetAllAsync();
            if (orders.Count() > 0)
            {
                var response = mapper.Map<List<OrderResponseDTO>>(orders);
                return TypedResults.Ok(response);
            }
            return TypedResults.NoContent();

        }
    }
}
