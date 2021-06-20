using System;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels.ClosingDateModels
{
    public class ClosingDateCreationDto
    {
        // Todo valid date if in the future
        public DateTime ClosingDateTime { get; set; }
    }
}
