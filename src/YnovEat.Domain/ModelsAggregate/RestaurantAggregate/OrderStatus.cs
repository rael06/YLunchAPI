using System;
using System.ComponentModel.DataAnnotations;
using DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public OrderState Status { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Order Order { get; set; }
    }
}
