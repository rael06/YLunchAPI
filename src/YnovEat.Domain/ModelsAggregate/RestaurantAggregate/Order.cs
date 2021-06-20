using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using YnovEat.Domain.DTO.OrderModels;
using YnovEat.Domain.ModelsAggregate.CustomerAggregate;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class Order
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CustomerComment { get; set; }
        public string RestaurantComment { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime? AcceptationDateTime { get; set; }
        public bool IsAccepted => AcceptationDateTime != null;

        public virtual ICollection<OrderStatus> OrderStatuses { get; set; } =
            new List<OrderStatus>();

        public OrderStatus CurrentOrderStatus => OrderStatuses.Last();

        public bool IsAcknowledged =>
            OrderStatuses.Any(os => os.Status.Equals(OrderState.Acknowledged));

        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } =
            new List<CustomerProduct>();

        [NotMapped]
        public ICollection<RestaurantProduct> RestaurantProducts { get; set; } =
            new List<RestaurantProduct>();

        public string RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public double TotalPrice { get; set; }

        public static Order Create(
            string id,
            OrderCreationDto orderCreationDto,
            Customer customer,
            ICollection<CustomerProduct> customerProducts,
            ICollection<RestaurantProduct> restaurantProducts
        )
        {
            return new Order
            {
                Id = id,
                CustomerComment = orderCreationDto.CustomerComment,
                RestaurantComment = orderCreationDto.RestaurantComment,
                TotalPrice = customerProducts.Sum(x => x.Price),
                CreationDateTime = DateTime.Now,
                CustomerId = customer.UserId,
                RestaurantId = customerProducts.First().RestaurantId,
                Customer = customer,
                CustomerProducts = customerProducts,
                RestaurantProducts = restaurantProducts,
                IsDeleted = false,
                OrderStatuses = new List<OrderStatus> {new(id)}
            };
        }
    }
}
