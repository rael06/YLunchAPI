using System;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class OrderStatus
    {
        public string Id { get; set; }
        public OrderState Status { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Order Order { get; set; }
    }
}
