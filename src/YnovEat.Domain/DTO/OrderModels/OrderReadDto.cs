using System;
using System.Collections.Generic;
using System.Linq;
using YnovEat.Domain.DTO.OrderModels.OrderStatusModels;
using YnovEat.Domain.DTO.ProductModels.CustomerProductModels;
using YnovEat.Domain.DTO.ProductModels.RestaurantProductModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.OrderModels
{
    public class OrderReadDto
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CustomerComment { get; set; }
        public string RestaurantComment { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? AcceptationDateTime { get; set; }
        public bool IsAccepted { get; set; }
        public string CustomerId { get; set; }
        public string RestaurantId { get; set; }
        public ICollection<OrderStatusReadDto> OrderStatuses { get; set; }
        public OrderStatusReadDto CurrentOrderStatus { get; set; }
        public bool IsAcknowledged { get; set; }
        public ICollection<CustomerProductReadDto> CustomerProducts { get; set; }
        public ICollection<RestaurantProductReadDto> RestaurantProducts { get; set; }
        public double TotalPrice { get; set; }

        public OrderReadDto(Order order)
        {
            Id = order.Id;
            IsDeleted = order.IsDeleted;
            CustomerComment = order.CustomerComment;
            RestaurantComment = order.RestaurantComment;
            CreationDateTime = order.CreationDateTime;
            TotalPrice = order.TotalPrice;
            AcceptationDateTime = order.AcceptationDateTime;
            IsAccepted = order.IsAccepted;
            CustomerId = order.CustomerId;
            RestaurantId = order.RestaurantId;
            OrderStatuses = order.OrderStatuses.Select(x=>new OrderStatusReadDto(x)).ToList();
            CurrentOrderStatus = new OrderStatusReadDto(order.CurrentOrderStatus);
            IsAcknowledged = order.IsAcknowledged;
            CustomerProducts = order.CustomerProducts.Select(x=>new CustomerProductReadDto(x)).ToList();
            RestaurantProducts = order.RestaurantProducts.Select(x=>new RestaurantProductReadDto(x)).ToList();
        }
    }
}
