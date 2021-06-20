using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.OrderModels;
using YnovEat.Domain.ModelsAggregate.CustomerAggregate;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.OrderServices;

namespace YnovEat.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRestaurantProductRepository _restaurantProductRepository;

        public OrderService(IOrderRepository orderRepository, IRestaurantProductRepository restaurantProductRepository)
        {
            _orderRepository = orderRepository;
            _restaurantProductRepository = restaurantProductRepository;
        }

        public async Task<OrderReadDto> Create(OrderCreationDto orderCreationDto, Customer customer)
        {
            var restaurantProducts =
                await _restaurantProductRepository.GetListByIds(orderCreationDto.ProductsId);

            var orderId = Guid.NewGuid().ToString();
            var customerProducts = restaurantProducts
                .Select(x => CustomerProduct.Create(x, orderId)).ToList();

            var order = Order.Create(orderId, orderCreationDto, customer, customerProducts);
            await _orderRepository.Create(order);
            return new OrderReadDto(order);
        }
    }
}
