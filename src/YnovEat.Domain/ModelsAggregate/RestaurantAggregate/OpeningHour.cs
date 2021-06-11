using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class OpeningHour
    {
        public string Id { get; set; }
        public int StartHourInMinutes { get; set; }
        public int EndHourInMinutes { get; set; }
        public int? OrderTimeLimitInMinutes { get; set; }
        public virtual DayOpeningHours DayOpeningHours { get; set; }
    }
}
