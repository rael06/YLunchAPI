using System.Collections.Generic;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.OrderModels;
using YnovEat.Domain.DTO.OrderModels.OrderStatusModels;
using YnovEat.Domain.ModelsAggregate.CustomerAggregate;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.Services.OrderServices
{
    public interface IOrderService
    {
        Task<OrderReadDto> Create(OrderCreationDto orderCreationDto, Customer customer);
        Task<OrderReadDto> AddStatus(OrderStatusCreationDto orderStatusCreationDto);

        Task<ICollection<OrderReadDto>> AddStatusToMultipleOrders(
            AddOrderStatusToMultipleOrdersDto addOrderStatusToMultipleOrdersDto);
    }
}
