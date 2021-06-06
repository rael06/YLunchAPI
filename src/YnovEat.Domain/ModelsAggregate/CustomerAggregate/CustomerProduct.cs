using System;
using System.ComponentModel.DataAnnotations;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.ModelsAggregate.CustomerAggregate
{
    public class CustomerProduct
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public double Price { get; set; }
        [Required] public DateTime CreationDateTime { get; set; }
        [Required] public int RestaurantProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Order Order { get; set; }
    }
}
