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
    }
}
