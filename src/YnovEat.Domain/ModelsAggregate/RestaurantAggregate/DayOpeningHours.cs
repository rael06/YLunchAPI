using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class DayOpeningHours
    {
        public int Id { get; set; }

        [Required]
        public int DayIndex { get; set; } // Sunday = 0, Saturday=6

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<OpeningHour> OpeningHours { get; set; } = new List<OpeningHour>();
    }
}
