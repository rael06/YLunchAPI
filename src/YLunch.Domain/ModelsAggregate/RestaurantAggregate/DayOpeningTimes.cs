using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using YLunch.Domain.DTO.RestaurantModels.OpeningTimeModels;

namespace YLunch.Domain.ModelsAggregate.RestaurantAggregate
{
    public class DayOpeningTimes
    {
        public string Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<OpeningTime> OpeningTimes { get; set; } =
            new List<OpeningTime>();

        public static DayOpeningTimes Create(DayOpeningTimesCreationDto dayOpeningTimesCreationDto, string restaurantId)
        {
            var dayOpeningTimesId = Guid.NewGuid().ToString();
            return new DayOpeningTimes
            {
                Id = dayOpeningTimesId,
                RestaurantId = restaurantId,
                DayOfWeek = dayOpeningTimesCreationDto.DayOfWeek,
                OpeningTimes = dayOpeningTimesCreationDto.OpeningTimes
                    .Select(x => OpeningTime.Create(x, dayOpeningTimesId)).ToList()
            };
        }
    }
}
