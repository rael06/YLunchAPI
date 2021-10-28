using System;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.DTO.RestaurantModels.OpeningTimeModels
{
    public class OpeningTimeCreationDto
    {
        public string StartTimeInMinutes { get; set; }
        public string EndTimeInMinutes { get; set; }
        public string StartOrderTimeInMinutes { get; set; }
        public string EndOrderTimeInMinutes { get; set; }
    }
}
