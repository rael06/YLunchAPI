using System;
using System.Collections.Generic;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }

        public virtual ICollection<RestaurantProductTag> RestaurantProductTags { get; set; } =
            new List<RestaurantProductTag>();

        public string RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public ProductFamilies ProductFamily { get; set; }
    }
}
