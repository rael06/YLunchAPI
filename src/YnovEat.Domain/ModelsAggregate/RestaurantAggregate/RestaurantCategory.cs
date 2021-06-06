using System.Collections.Generic;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RestaurantCategoryLink> RestaurantCategoryLinks { get; set; }
    }
}
