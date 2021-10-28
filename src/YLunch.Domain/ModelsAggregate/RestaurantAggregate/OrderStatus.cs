using System;
using YLunch.Domain.DTO.OrderModels.OrderStatusModels;
using YLunch.DomainShared.RestaurantAggregate.Enums;

namespace YLunch.Domain.ModelsAggregate.RestaurantAggregate
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

        public static OrderStatus Create(string orderId, OrderState state)
        {
            return new ()
            {
                Id = Guid.NewGuid().ToString(),
                State = state,
                DateTime = DateTime.Now,
                OrderId = orderId
            };
        }
    }
}
