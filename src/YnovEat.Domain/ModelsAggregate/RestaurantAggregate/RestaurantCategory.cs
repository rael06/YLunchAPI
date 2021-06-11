using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; } =
            new List<Restaurant>();
    }
}
