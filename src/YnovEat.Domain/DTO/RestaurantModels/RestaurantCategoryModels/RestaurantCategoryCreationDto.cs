using System;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels.RestaurantCategoryModels
{
    public class RestaurantCategoryCreationDto
    {
        public string Name { get; set; }

        public RestaurantCategory CreateRestaurantCategory()
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name
            };
        }
    }
}
