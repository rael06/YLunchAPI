using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.DTO.ProductModels.RestaurantProductModels
{
    public class RestaurantProductCreationDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ExpirationDateTime { get; set; }

        [Range(0, ProductFamiliesUtils.Count, ErrorMessage = "ProductFamily is out of range")]
        public ProductFamilies? ProductFamily { get; set; }

        public RestaurantProduct CreateRestaurantProduct(string restaurantId)
        {
            var restaurantProductId = Guid.NewGuid().ToString();
            return new RestaurantProduct
            {
                Id = restaurantProductId,
                Name = Name,
                Description = Description,
                Price = Price,
                Quantity = Quantity,
                IsActive = IsActive ?? false,
                ExpirationDateTime = ExpirationDateTime,
                CreationDateTime = DateTime.Now,
                ProductFamily = ProductFamily ?? ProductFamilies.Other,
                RestaurantProductTags = new List<RestaurantProductTag>(),
                RestaurantId = restaurantId
            };
        }

    }
}
