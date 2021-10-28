using System;
using YLunch.Domain.ModelsAggregate.CustomerAggregate;
using YLunch.Domain.DTO.OrderModels;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.DTO.ProductModels.CustomerProductModels
{
    public class CustomerProductReadDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string RestaurantProductId { get; set; }
        public string RestaurantId { get; set; }
        public string OrderId { get; set; }

        public CustomerProductReadDto(CustomerProduct customerProduct)
        {
            Id = customerProduct.Id;
            Name = customerProduct.Name;
            Image = customerProduct.Image;
            Description = customerProduct.Description;
            Price = customerProduct.Price;
            CreationDateTime = customerProduct.CreationDateTime;
            RestaurantProductId = customerProduct.RestaurantProductId;
            RestaurantId = customerProduct.RestaurantId;
            OrderId = customerProduct.OrderId;
        }
    }
}
