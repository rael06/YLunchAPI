using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.Utils;

namespace YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels
{
    public class OpeningTimeReadDto
    {
        public string Id { get; set; }
        public string StartTimeInMinutes { get; set; }
        public string EndTimeInMinutes { get; set; }
        public string StartOrderTimeInMinutes { get; set; }
        public string EndOrderTimeInMinutes { get; set; }
        public string DayOpeningTimesId { get; set; }

        public OpeningTimeReadDto(OpeningTime entity)
        {
            Id = entity.Id;
            StartTimeInMinutes = TimeUtils.ToStrTime(entity.StartTimeInMinutes);
            EndTimeInMinutes = TimeUtils.ToStrTime(entity.EndTimeInMinutes);
            StartOrderTimeInMinutes = TimeUtils.ToStrTime(entity.StartOrderTimeInMinutes);
            EndOrderTimeInMinutes = TimeUtils.ToStrTime(entity.EndOrderTimeInMinutes);
            DayOpeningTimesId = entity.DayOpeningTimes.Id;
        }
    }
}
