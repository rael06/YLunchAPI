using System.Collections.Generic;
using DomainShared.RestaurantAggregate.Enums;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.ModelsAggregate.CustomerAggregate
{
    public class Customer
    {
        public string UserId { get; set; }
        public string CartId { get; set; }
        public CustomerFamily CustomerFamily { get; set; }
        public virtual User User { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
