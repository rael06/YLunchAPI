using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantProductCategory
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
