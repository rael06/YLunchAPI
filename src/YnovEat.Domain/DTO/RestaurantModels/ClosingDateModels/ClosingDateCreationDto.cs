using System;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels.ClosingDateModels
{
    public class ClosingDateCreationDto
    {
        public DateTime ClosingDateTime { get; set; }

        public ClosingDate CreateClosingDate(string restaurantId) =>
            new()
            {
                Id = Guid.NewGuid().ToString(),
                RestaurantId = restaurantId,
                ClosingDateTime = ClosingDateTime
            };
    }
}
