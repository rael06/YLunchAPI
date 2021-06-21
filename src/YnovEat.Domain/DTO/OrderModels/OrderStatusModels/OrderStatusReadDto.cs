using System;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.DTO.OrderModels.OrderStatusModels
{
    public class OrderStatusReadDto
    {
        public string Id { get; set; }
        public OrderState Status { get; set; }
        public DateTime DateTime { get; set; }
        public string OrderId { get; set; }

        public OrderStatusReadDto(OrderStatus orderStatus)
        {
            Id = orderStatus.Id;
            Status = orderStatus.State;
            DateTime = orderStatus.DateTime;
            OrderId = orderStatus.OrderId;
        }
    }
}
