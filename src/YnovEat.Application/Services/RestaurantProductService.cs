using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.ProductModels.RestaurantProductModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.RestaurantServices;

namespace YnovEat.Application.Services
{
    public class RestaurantProductService : IRestaurantProductService
    {
        private readonly IRestaurantProductRepository _restaurantProductRepository;

        public RestaurantProductService(IRestaurantProductRepository restaurantProductRepository)
        {
            _restaurantProductRepository = restaurantProductRepository;
        }

        public async Task<RestaurantProductReadDto> Create(RestaurantProductCreationDto restaurantProductCreationDto,
            string restaurantId)
        {
            var restaurantProduct = restaurantProductCreationDto.CreateRestaurantProduct(restaurantId);
            await _restaurantProductRepository.Create(restaurantProduct);
            return new RestaurantProductReadDto(restaurantProduct);
        }

        public async Task<RestaurantProductReadDto> Update(
            RestaurantProductModificationDto restaurantProductModificationDto,
            RestaurantProduct restaurantProduct)
        {
            var updatedRestaurantProduct = restaurantProductModificationDto.UpdateRestaurantProduct(restaurantProduct);
            await _restaurantProductRepository.Update();
            return new RestaurantProductReadDto(updatedRestaurantProduct);
        }

        public async Task<ICollection<RestaurantProductReadDto>> GetAllByRestaurantId(string restaurantId)
        {
            var restaurantProducts = await _restaurantProductRepository.GetAllByRestaurantId(restaurantId);
            return restaurantProducts.Select(x => new RestaurantProductReadDto(x)).ToList();
        }

        public async Task Delete(string restaurantProductId)
        {
            await _restaurantProductRepository.Delete(restaurantProductId);
        }
    }
}
