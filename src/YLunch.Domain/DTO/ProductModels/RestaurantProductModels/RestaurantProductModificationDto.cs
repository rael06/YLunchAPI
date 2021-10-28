using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YLunch.Domain.DTO.ProductModels.RestaurantProductModels
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

        [Range(0, ProductFamilyUtils.Count, ErrorMessage = "ProductFamily is out of range")]
        public ProductFamily? ProductFamily { get; set; }
    }
}
