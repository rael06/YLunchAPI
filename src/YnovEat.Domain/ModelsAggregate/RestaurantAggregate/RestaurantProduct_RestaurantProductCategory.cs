namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantProductCategoryLink
    {
        public int ProductId { get; set; }
        public virtual RestaurantProduct RestaurantProduct { get; set; }

        public int ProductCategoryId { get; set; }
        public virtual RestaurantProductCategory RestaurantProductCategory { get; set; }
    }
}
