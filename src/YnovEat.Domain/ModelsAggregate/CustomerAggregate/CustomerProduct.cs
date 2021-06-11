using System;
using System.ComponentModel.DataAnnotations;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.ModelsAggregate.CustomerAggregate
{
    public class CustomerProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int RestaurantProductId { get; set; }
        public string CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
