using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YLunch.Domain.DTO.RestaurantModels.RestaurantCategoryModels;

namespace YLunch.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; } =
            new List<Restaurant>();

        public static RestaurantCategory Create(RestaurantCategoryCreationDto restaurantCategoryCreationDto)
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = restaurantCategoryCreationDto.Name
            };
        }
    }
}
