using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DomainShared.RestaurantAggregate.Enums;
using YnovEat.Domain.ModelsAggregate.CustomerAggregate;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public bool IsDeleted { get; set; }
        public string Comment { get; set; }

        public DateTime? CreationDateTime => OrderStatuses.FirstOrDefault()?.DateTime;
        public DateTime? AcceptationDateTime { get; set; }
        public bool IsAccepted => AcceptationDateTime != null;

        public virtual ICollection<OrderStatus> OrderStatuses { get; set; } =
            new List<OrderStatus>();

        public OrderStatus CurrentOrderStatus => OrderStatuses.Last();

        public bool IsAcknowledged =>
            OrderStatuses.Any(os => os.Status.Equals(OrderState.Acknowledged));
        public virtual Customer Customer { get; set; }

        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } =
            new List<CustomerProduct>();

        public ICollection<RestaurantProduct> RestaurantProducts => new List<RestaurantProduct>();
    }
}
