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
        public string Comment { get; set; }

        public DateTime? CreationDateTime => OrderStatuses.FirstOrDefault()?.DateTime;
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

        public ICollection<RestaurantProduct> RestaurantProducts => new List<RestaurantProduct>();

        public static Order Create(string id, OrderCreationDto orderCreationDto, Customer customer, ICollection<CustomerProduct> customerProducts)
        {
            return new Order
            {
                Id = id,
                Comment = orderCreationDto.Comment,
                CustomerId = customer.UserId,
                Customer = customer,
                CustomerProducts = customerProducts,
                IsDeleted = false,
                OrderStatuses = new List<OrderStatus> {new OrderStatus(id)}
            };
        }
    }
}
