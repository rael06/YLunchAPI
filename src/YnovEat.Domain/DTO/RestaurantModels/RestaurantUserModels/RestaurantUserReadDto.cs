using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels.RestaurantUserModels
{
    public class RestaurantUserReadDto : IDtoConverter<RestaurantUser>
    {
        public string UserId { get; set; }
        public string RestaurantId { get; set; }
        public string Type { get; set; }

        public RestaurantUserReadDto(RestaurantUser restaurantUser)
        {
            FromEntity(restaurantUser);
        }

        public void FromEntity(RestaurantUser entity)
        {
            UserId = entity.UserId;
            RestaurantId = entity.RestaurantId;
            Type = entity.Discriminator;
        }
    }
}
