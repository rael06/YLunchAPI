using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YLunch.Domain.DTO.OrderModels.OrderStatusModels
{
    public class AddOrderStatusToMultipleOrdersDto
    {

        public ICollection<string> OrdersId { get; set; }

        [Range(0, OrderStateUtils.Count, ErrorMessage = "OrderState is out of range")]
        public OrderState State { get; set; }
    }
}
