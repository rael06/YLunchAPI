using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels
{
    public class OpeningTimeReadDto : IDtoConverter<OpeningTime>
    {
        public string Id { get; set; }
        public int StartTimeInMinutes { get; set; }
        public int EndTimeInMinutes { get; set; }
        public int? StartOrderTimeInMinutes { get; set; }
        public int? EndOrderTimeInMinutes { get; set; }
        public string DayOpeningTimesId { get; set; }

        public OpeningTimeReadDto(OpeningTime openingTime)
        {
            FromEntity(openingTime);
        }

        public void FromEntity(OpeningTime entity)
        {
            Id = entity.Id;
            StartTimeInMinutes = entity.StartTimeInMinutes;
            EndTimeInMinutes = entity.EndTimeInMinutes;
            StartOrderTimeInMinutes = entity.StartOrderTimeInMinutes;
            EndOrderTimeInMinutes = entity.EndOrderTimeInMinutes;
            DayOpeningTimesId = entity.DayOpeningTimes.Id;
        }
    }
}
