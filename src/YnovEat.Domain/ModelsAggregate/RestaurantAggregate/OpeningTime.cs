using System;
using System.ComponentModel.DataAnnotations;
using YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels;
using YnovEat.Domain.Utils;

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

        public static OpeningTime Create(OpeningTimeCreationDto openingTimeCreationDto, string dayOpeningTimesId)
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                DayOpeningTimesId = dayOpeningTimesId,
                StartTimeInMinutes = TimeUtils.ToMinutes(openingTimeCreationDto.StartTimeInMinutes),
                EndTimeInMinutes = TimeUtils.ToMinutes(openingTimeCreationDto.EndTimeInMinutes),
                StartOrderTimeInMinutes = TimeUtils.ToNullableMinutes(openingTimeCreationDto.StartOrderTimeInMinutes),
                EndOrderTimeInMinutes = TimeUtils.ToNullableMinutes(openingTimeCreationDto.EndOrderTimeInMinutes)
            };
        }
    }
}
