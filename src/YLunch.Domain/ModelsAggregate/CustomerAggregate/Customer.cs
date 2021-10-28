using System.Collections.Generic;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YLunch.Domain.ModelsAggregate.CustomerAggregate
{
    public class Customer
    {
        public string UserId { get; set; }
        public CustomerFamily CustomerFamily { get; set; }
        public virtual User User { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public static Customer Create(string userId)
        {
            return new()
            {
                CustomerFamily = CustomerFamily.Student,
                UserId = userId
            };
        }
    }
}
