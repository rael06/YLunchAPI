using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public abstract class RestaurantUser
    {
        public string Id { get; set; }
        public virtual User User { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
