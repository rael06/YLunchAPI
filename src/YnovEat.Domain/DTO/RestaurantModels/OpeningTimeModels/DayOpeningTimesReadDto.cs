using System;
using System.Collections.Generic;
using System.Linq;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels
{
    public class DayOpeningTimesReadDto : IDtoConverter<DayOpeningTimes>
    {
        public string Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string RestaurantId { get; set; }
        public virtual ICollection<OpeningTimeReadDto> OpeningTimes { get; set; } =
            new List<OpeningTimeReadDto>();

        public DayOpeningTimesReadDto(DayOpeningTimes dayOpeningTimes)
        {
            FromEntity(dayOpeningTimes);
        }

        public void FromEntity(DayOpeningTimes entity)
        {
            Id = entity.Id;
            DayOfWeek = entity.DayOfWeek;
            RestaurantId=entity.RestaurantId;
            OpeningTimes = entity.OpeningTimes.Select(x => new OpeningTimeReadDto(x)).ToList();
        }
    }
}
