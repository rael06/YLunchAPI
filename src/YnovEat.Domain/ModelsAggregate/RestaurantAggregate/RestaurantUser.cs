using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public abstract class RestaurantUser
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public string Discriminator { get; set; }

        public static RestaurantOwner CreateOwner(string userId)
        {
            return new()
            {
                UserId = userId,
                Discriminator = nameof(RestaurantOwner)
            };
        }

        public static RestaurantAdmin CreateAdmin(string userId, string restaurantId)
        {
            return new()
            {
                UserId = userId,
                RestaurantId = restaurantId,
                Discriminator = nameof(RestaurantAdmin)
            };
        }

        public static RestaurantEmployee CreateEmployee(string userId, string restaurantId)
        {
            return new()
            {
                UserId = userId,
                RestaurantId = restaurantId,
                Discriminator = nameof(RestaurantEmployee)
            };
        }
    }
}
