using System;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class ClosingDate
    {
        public int Id { get; set; }
        [Required] public DateTime ClosingDateTime { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
