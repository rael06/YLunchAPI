using System.Collections.Generic;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class ProductCategory
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<ProductCategoryLink> ProductCategoryLinks { get; set; }
    }
}
