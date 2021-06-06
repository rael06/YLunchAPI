using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using YnovEat.Domain.ModelsAggregate.CustomerAggregate;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public bool IsPassed { get; set; }
        public string Comment { get; set; }

        [NotMapped] public DateTime? CreationDateTime => OrderStatuses.FirstOrDefault()?.DateTime;
        public DateTime? AcceptationDateTime { get; set; }
        [NotMapped] public bool IsAccepted => AcceptationDateTime != null;


        public virtual ICollection<OrderStatus> OrderStatuses { get; set; } =
            new List<OrderStatus>();

        [NotMapped] public OrderStatus CurrentOrderStatus => OrderStatuses.Last();

        // Todo create enum of order statuses
        [NotMapped] public bool IsAcknowledged =>
            OrderStatuses.Any(os => os.Name.Equals("Acknowledged"));
        public virtual Customer Customer { get; set; }

        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } =
            new List<CustomerProduct>();

        [NotMapped] public ICollection<RestaurantProduct> RestaurantProducts { get; set; }
    }
}
