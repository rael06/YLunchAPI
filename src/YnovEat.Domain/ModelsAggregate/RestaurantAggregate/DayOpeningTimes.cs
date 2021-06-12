using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class DayOpeningTimes
    {
        public string Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<OpeningTime> OpeningTimes { get; set; } =
            new List<OpeningTime>();
    }
}
