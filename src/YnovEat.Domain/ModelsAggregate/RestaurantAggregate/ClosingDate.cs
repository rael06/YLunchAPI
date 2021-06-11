using System;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class ClosingDate
    {
        public string Id { get; set; }
        public DateTime ClosingDateTime { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
