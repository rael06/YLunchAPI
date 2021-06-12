using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class OpeningTime
    {
        public string Id { get; set; }
        public int StartTimeInMinutes { get; set; }
        public int EndTimeInMinutes { get; set; }
        public int? StartOrderTimeInMinutes { get; set; }
        public int? EndOrderTimeInMinutes { get; set; }
        public string DayOpeningTimesId { get; set; }
        public virtual DayOpeningTimes DayOpeningTimes { get; set; }
    }
}
