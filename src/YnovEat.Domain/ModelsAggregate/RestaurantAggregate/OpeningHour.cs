using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class OpeningHour
    {
        public int Id { get; set; }

        [Required]
        public int HourInMinutes { get; set; }

        public virtual DayOpeningHours DayOpeningHours { get; set; }
    }
}
