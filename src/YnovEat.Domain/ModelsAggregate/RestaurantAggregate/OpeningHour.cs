using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class OpeningHour
    {
        public int Id { get; set; }
        public int StartHourInMinutes { get; set; }
        public int EndHourInMinutes { get; set; }
        public virtual DayOpeningHours DayOpeningHours { get; set; }
    }
}
