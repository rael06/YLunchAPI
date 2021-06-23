using System.Collections.Generic;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.ProductModels.RestaurantProductModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.Services.RestaurantServices
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
