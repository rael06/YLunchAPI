using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YLunch.Domain.DTO.ProductModels.RestaurantProductModels
{
    public class RestaurantProductReadDto
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
        public string RestaurantId { get; set; }
        public ProductFamily ProductFamily { get; set; }

        public RestaurantProductReadDto(RestaurantProduct restaurantProduct)
        {
            Id = restaurantProduct.Id;
            Name = restaurantProduct.Name;
            Image = restaurantProduct.Image;
            Description = restaurantProduct.Description;
            Price = restaurantProduct.Price;
            Quantity = restaurantProduct.Quantity;
            IsActive = restaurantProduct.IsActive;
            CreationDateTime = restaurantProduct.CreationDateTime;
            ExpirationDateTime = restaurantProduct.ExpirationDateTime;
            ProductFamily = restaurantProduct.ProductFamily;
            RestaurantId = restaurantProduct.RestaurantId;
        }
    }
}
