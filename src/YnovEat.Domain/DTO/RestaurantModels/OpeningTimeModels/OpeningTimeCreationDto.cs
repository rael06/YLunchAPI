using System;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels
{
    public class OpeningTimeCreationDto
    {
        public int StartTimeInMinutes { get; set; }
        public int EndTimeInMinutes { get; set; }
        public int? StartOrderTimeInMinutes { get; set; }
        public int? EndOrderTimeInMinutes { get; set; }

        public OpeningTime CreateOpeningTime(string dayOpeningTimesId) {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                DayOpeningTimesId = dayOpeningTimesId,
                StartTimeInMinutes = StartTimeInMinutes,
                EndTimeInMinutes = EndTimeInMinutes,
                StartOrderTimeInMinutes = StartOrderTimeInMinutes,
                EndOrderTimeInMinutes = EndOrderTimeInMinutes
            };
        }
    }
}
