using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.DTO.RestaurantModels.RestaurantCategoryModels
{
    public class RestaurantCategoryReadDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public RestaurantCategoryReadDto(RestaurantCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}
