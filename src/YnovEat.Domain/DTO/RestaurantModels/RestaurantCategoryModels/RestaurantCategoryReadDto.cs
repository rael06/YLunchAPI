using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels.RestaurantCategoryModels
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
