using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class DayOpeningHours
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<OpeningHour> OpeningHours { get; set; } =
            new List<OpeningHour>();
    }
}
