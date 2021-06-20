using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.DTO.ProductModels.RestaurantProductModels
{
    public class RestaurantProductModificationDto
    {
        [Required] public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ExpirationDateTime { get; set; }

        [Range(0, ProductFamiliesUtils.Count, ErrorMessage = "ProductFamily is out of range")]
        public ProductFamilies? ProductFamily { get; set; }

        public RestaurantProduct UpdateRestaurantProduct(RestaurantProduct restaurantProduct)
        {
            restaurantProduct.Name = Name ?? restaurantProduct.Name;
            restaurantProduct.Image = Image ?? restaurantProduct.Image;
            restaurantProduct.Description = Description ?? restaurantProduct.Description;
            restaurantProduct.Price = Price ?? restaurantProduct.Price;
            restaurantProduct.Quantity = Quantity ?? restaurantProduct.Quantity;
            restaurantProduct.IsActive = IsActive ?? restaurantProduct.IsActive;
            restaurantProduct.ExpirationDateTime = ExpirationDateTime ?? restaurantProduct.ExpirationDateTime;
            restaurantProduct.ProductFamily = ProductFamily ?? restaurantProduct.ProductFamily;

            return restaurantProduct;
        }
    }
}
