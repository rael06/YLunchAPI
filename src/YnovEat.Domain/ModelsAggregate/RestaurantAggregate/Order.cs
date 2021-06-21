using System;
using System.Collections.Generic;
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
            OrderStatuses.Any(os => os.State.Equals(OrderState.Acknowledged));

        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } =
            new List<CustomerProduct>();

        public string RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public double TotalPrice { get; set; }

        public static Order Create(
            string id,
            OrderCreationDto orderCreationDto,
            Customer customer,
            ICollection<CustomerProduct> customerProducts
        )
        {
            return new()
            {
                Id = id,
                CustomerComment = orderCreationDto.CustomerComment,
                RestaurantComment = orderCreationDto.RestaurantComment,
                TotalPrice = Math.Round(customerProducts.Sum(x => x.Price), 2),
                CreationDateTime = DateTime.Now,
                CustomerId = customer.UserId,
                RestaurantId = customerProducts.First().RestaurantId,
                Customer = customer,
                CustomerProducts = customerProducts,
                IsDeleted = false,
                OrderStatuses = new List<OrderStatus> {OrderStatus.Create(id)}
            };
        }
    }
}
