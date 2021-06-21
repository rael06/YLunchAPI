using System;
using YnovEat.Domain.DTO.OrderModels.OrderStatusModels;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class OrderStatus
    {
        public string Id { get; set; }
        public OrderState State { get; set; }
        public DateTime DateTime { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

        public static OrderStatus Create(string orderId)
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                State = OrderState.Idling,
                DateTime = DateTime.Now,
                OrderId = orderId
            };
        }

        public static OrderStatus Create(OrderStatusCreationDto orderStatusCreationDto)
        {
            return new ()
            {
                Id = Guid.NewGuid().ToString(),
                State = orderStatusCreationDto.State,
                DateTime = DateTime.Now,
                OrderId = orderStatusCreationDto.OrderId
            };
        }
    }
}
