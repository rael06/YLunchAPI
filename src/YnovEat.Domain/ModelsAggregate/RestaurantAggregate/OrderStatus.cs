using System;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class OrderStatus
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public DateTime DateTime { get; set; }
        public virtual Order Order { get; set; }
    }
}
