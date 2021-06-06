namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class RestaurantProduct_RestaurantProductCategory
    {
        public int RestaurantProductId { get; set; }
        public virtual RestaurantProduct RestaurantProduct { get; set; }

        public int RestaurantProductCategoryId { get; set; }
        public virtual RestaurantProductCategory RestaurantProductCategory { get; set; }
    }
}
