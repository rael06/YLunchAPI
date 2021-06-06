using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantCategory
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }

        public ICollection<Restaurant_RestaurantCategory> Restaurant_RestaurantCategory_Links { get; set; } =
            new List<Restaurant_RestaurantCategory>();
    }
}
