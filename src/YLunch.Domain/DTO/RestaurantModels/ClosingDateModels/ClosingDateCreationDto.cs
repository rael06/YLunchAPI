using System;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.DTO.RestaurantModels.ClosingDateModels
{
    public class ClosingDateCreationDto
    {
        // Todo valid date if in the future
        public DateTime ClosingDateTime { get; set; }
    }
}
