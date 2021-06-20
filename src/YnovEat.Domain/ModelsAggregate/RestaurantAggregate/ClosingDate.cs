using System;
using System.ComponentModel.DataAnnotations;
using YnovEat.Domain.DTO.RestaurantModels.ClosingDateModels;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class ClosingDate
    {
        public string Id { get; set; }
        public DateTime ClosingDateTime { get; set; }
        public string RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public static ClosingDate Create(ClosingDateCreationDto closingDateCreationDto, string restaurantId)
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                RestaurantId = restaurantId,
                ClosingDateTime = closingDateCreationDto.ClosingDateTime
            };
        }
    }
}
