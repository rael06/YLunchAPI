using System;
using System.Collections.Generic;
using YLunch.Domain.DTO.ProductModels.RestaurantProductModels;
using YLunch.DomainShared.RestaurantAggregate.Enums;

namespace YLunch.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }

        public virtual ICollection<RestaurantProductTag> RestaurantProductTags { get; set; } =
            new List<RestaurantProductTag>();

        public string RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public ProductFamily ProductFamily { get; set; }

        public static RestaurantProduct Create(RestaurantProductCreationDto restaurantProductCreationDto, string restaurantId)
        {
                var restaurantProductId = Guid.NewGuid().ToString();
                return new RestaurantProduct
                {
                    Id = restaurantProductId,
                    Name = restaurantProductCreationDto.Name,
                    Description = restaurantProductCreationDto.Description,
                    Image = restaurantProductCreationDto.Image,
                    Price = restaurantProductCreationDto.Price,
                    Quantity = restaurantProductCreationDto.Quantity,
                    IsActive = restaurantProductCreationDto.IsActive ?? false,
                    ExpirationDateTime = restaurantProductCreationDto.ExpirationDateTime,
                    CreationDateTime = DateTime.Now,
                    ProductFamily = restaurantProductCreationDto.ProductFamily ?? ProductFamily.Other,
                    RestaurantProductTags = new List<RestaurantProductTag>(),
                    RestaurantId = restaurantId
                };
        }

        public void Update(RestaurantProductModificationDto restaurantProductModificationDto)
        {
            Name = restaurantProductModificationDto.Name ?? Name;
            Image = restaurantProductModificationDto.Image ?? Image;
            Description = restaurantProductModificationDto.Description ?? Description;
            Price = restaurantProductModificationDto.Price ?? Price;
            Quantity = restaurantProductModificationDto.Quantity ?? Quantity;
            IsActive = restaurantProductModificationDto.IsActive ?? IsActive;
            ExpirationDateTime = restaurantProductModificationDto.ExpirationDateTime ?? ExpirationDateTime;
            ProductFamily = restaurantProductModificationDto.ProductFamily ?? ProductFamily;
        }
    }
}
