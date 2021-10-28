using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.DTO.RestaurantModels.OpeningTimeModels
{
    public class DayOpeningTimesCreationDto
    {
        [Range(0, 6, ErrorMessage = "Day must be in range 0-6, 0 is sunday, 6 is saturday")]
        public DayOfWeek DayOfWeek { get; set; }

        public virtual ICollection<OpeningTimeCreationDto> OpeningTimes { get; set; } =
            new List<OpeningTimeCreationDto>();
    }
}
