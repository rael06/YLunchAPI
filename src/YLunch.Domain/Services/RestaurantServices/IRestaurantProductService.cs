using System.Collections.Generic;
using System.Threading.Tasks;
using YLunch.Domain.DTO.ProductModels.RestaurantProductModels;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.Services.RestaurantServices
{
    public interface IRestaurantProductService
    {
        Task<RestaurantProductReadDto> Create(RestaurantProductCreationDto restaurantProductCreationDto, string restaurantId);
        Task<RestaurantProductReadDto> Update(RestaurantProductModificationDto restaurantProductModificationDto,
            RestaurantProduct restaurantProduct);

        Task<ICollection<RestaurantProductReadDto>> GetAllByRestaurantId(string restaurantId);
        Task<ICollection<RestaurantProductReadDto>> GetAllForCustomerByRestaurantId(string restaurantId);
        Task Delete(string restaurantProductId);
    }
}
