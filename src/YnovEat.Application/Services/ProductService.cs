using System;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.ProductModels.RestaurantProductModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.RestaurantServices;

namespace YnovEat.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RestaurantProductReadDto> Create(RestaurantProductCreationDto restaurantProductCreationDto,
            string restaurantId)
        {
            var restaurantProduct = restaurantProductCreationDto.CreateRestaurantProduct(restaurantId);
            await _productRepository.Create(restaurantProduct);
            return new RestaurantProductReadDto(restaurantProduct);
        }

        public async Task<RestaurantProductReadDto> Update(RestaurantProductModificationDto restaurantProductModificationDto,
            RestaurantProduct restaurantProduct)
        {
            var updatedRestaurantProduct = restaurantProductModificationDto.UpdateRestaurantProduct(restaurantProduct);
            await _productRepository.Update();
            return new RestaurantProductReadDto(updatedRestaurantProduct);
        }
    }
}
