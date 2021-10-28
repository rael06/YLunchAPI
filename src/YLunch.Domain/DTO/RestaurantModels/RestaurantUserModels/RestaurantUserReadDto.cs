using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.DTO.RestaurantModels.RestaurantUserModels
{
    public class RestaurantUserReadDto
    {
        public string UserId { get; set; }
        public string RestaurantId { get; set; }
        public string Type { get; set; }

        public RestaurantUserReadDto(RestaurantUser entity)
        {
            UserId = entity.UserId;
            RestaurantId = entity.RestaurantId;
            Type = entity.Discriminator;
        }
    }
}
