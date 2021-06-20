using System;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels
{
    public class OpeningTimeCreationDto
    {
        public string StartTimeInMinutes { get; set; }
        public string EndTimeInMinutes { get; set; }
        public string StartOrderTimeInMinutes { get; set; }
        public string EndOrderTimeInMinutes { get; set; }
    }
}
