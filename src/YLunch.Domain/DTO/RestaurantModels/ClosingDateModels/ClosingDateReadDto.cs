using System;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.DTO.RestaurantModels.ClosingDateModels
{
    public class ClosingDateReadDto
    {
        public string Id { get; set; }
        public DateTime ClosingDateTime { get; set; }
        public string RestaurantId { get; set; }

        public ClosingDateReadDto(ClosingDate entity)
        {
            Id = entity.Id;
            ClosingDateTime = entity.ClosingDateTime;
            RestaurantId = entity.RestaurantId;
        }
    }
}
