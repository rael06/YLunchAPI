using System.Collections.Generic;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.ModelsAggregate.CustomerAggregate
{
    public class Customer
    {
        public string Id { get; set; }
        public CustomerFamily CustomerFamily { get; set; }
        public virtual User User { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
