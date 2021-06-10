using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DomainShared.RestaurantAggregate.Enums;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }

        public virtual ICollection<RestaurantProductTag> RestaurantProductTags { get; set; } =
            new List<RestaurantProductTag>();

        public virtual Restaurant Restaurant { get; set; }

        public ProductFamily ProductFamily { get; set; }
    }
}
