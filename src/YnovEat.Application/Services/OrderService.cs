using System;
using System.Linq;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.OrderModels;
using YnovEat.Domain.DTO.OrderModels.OrderStatusModels;
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
                _restaurantProductRepository.GetListByIds(orderCreationDto.ProductsId);

            var orderId = Guid.NewGuid().ToString();
            var customerProducts = restaurantProducts
                .Select(x => CustomerProduct.Create(x, orderId)).ToList();

            var order = Order.Create(orderId, orderCreationDto, customer, customerProducts);
            await _orderRepository.Create(order);
            return new OrderReadDto(order);
        }

        public async Task<OrderReadDto> AddStatus(OrderStatusCreationDto orderStatusCreationDto)
        {
            var order = await _orderRepository.GetById(orderStatusCreationDto.OrderId);
            order.OrderStatuses.Add(OrderStatus.Create(orderStatusCreationDto));
            await _orderRepository.Update();
            return new OrderReadDto(order);
        }
    }
}
