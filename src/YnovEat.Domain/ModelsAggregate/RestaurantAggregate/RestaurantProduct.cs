using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantProduct
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public double Price { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public bool IsActive { get; set; }
        [Required] public DateTime CreationDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }

        public virtual ICollection<RestaurantProductCategory> RestaurantProductCategories { get; set; } =
            new List<RestaurantProductCategory>();

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<RestaurantProduct_RestaurantProductCategory>
            Restaurant_RestaurantProductCategory_Links { get; set; } =
            new List<RestaurantProduct_RestaurantProductCategory>();
    }
}
