using System;
using System.Collections.Generic;
using YnovEat.Domain.DTO.ProductModels.RestaurantProductModels;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }

        public virtual ICollection<RestaurantProductTag> RestaurantProductTags { get; set; } =
            new List<RestaurantProductTag>();

        public string RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public ProductFamilies ProductFamily { get; set; }

        public static RestaurantProduct Create(RestaurantProductCreationDto restaurantProductCreationDto, string restaurantId)
        {
                var restaurantProductId = Guid.NewGuid().ToString();
                return new RestaurantProduct
                {
                    Id = restaurantProductId,
                    Name = restaurantProductCreationDto.Name,
                    Description = restaurantProductCreationDto.Description,
                    Price = restaurantProductCreationDto.Price,
                    Quantity = restaurantProductCreationDto.Quantity,
                    IsActive = restaurantProductCreationDto.IsActive ?? false,
                    ExpirationDateTime = restaurantProductCreationDto.ExpirationDateTime,
                    CreationDateTime = DateTime.Now,
                    ProductFamily = restaurantProductCreationDto.ProductFamily ?? ProductFamilies.Other,
                    RestaurantProductTags = new List<RestaurantProductTag>(),
                    RestaurantId = restaurantId
                };
        }
    }
}
