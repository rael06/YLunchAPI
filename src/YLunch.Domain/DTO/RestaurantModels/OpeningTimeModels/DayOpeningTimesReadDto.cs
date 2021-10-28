using System;
using System.Collections.Generic;
using System.Linq;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.DTO.RestaurantModels.OpeningTimeModels
{
    public class DayOpeningTimesReadDto
    {
        public string Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string RestaurantId { get; set; }
        public ICollection<OpeningTimeReadDto> OpeningTimes { get; set; }

        public DayOpeningTimesReadDto(DayOpeningTimes entity)
        {
            Id = entity.Id;
            DayOfWeek = entity.DayOfWeek;
            RestaurantId=entity.RestaurantId;
            OpeningTimes = entity.OpeningTimes.Select(x => new OpeningTimeReadDto(x)).ToList();
        }
    }
}
