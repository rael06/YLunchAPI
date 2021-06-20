using System;
using System.ComponentModel.DataAnnotations;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.ModelsAggregate.CustomerAggregate
{
    public class CustomerProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string RestaurantProductId { get; set; }
        public string RestaurantId { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

        public static CustomerProduct Create(RestaurantProduct restaurantProduct, string orderId)
        {
            return new CustomerProduct
            {
                Id = Guid.NewGuid().ToString(),
                Name = restaurantProduct.Name,
                Description = restaurantProduct.Description,
                Price = restaurantProduct.Price,
                CreationDateTime = restaurantProduct.CreationDateTime,
                RestaurantProductId = restaurantProduct.Id,
                RestaurantId = restaurantProduct.RestaurantId,
                OrderId = orderId
            };
        }
    }
}
