namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantCategoryLink
    {
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public int RestaurantCategoryId { get; set; }
        public virtual RestaurantCategory RestaurantCategory { get; set; }
    }
}
