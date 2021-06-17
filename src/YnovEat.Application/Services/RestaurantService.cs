using System.Threading.Tasks;
using YnovEat.Application.Exceptions;
using YnovEat.Domain.DTO.RestaurantModels;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.RestaurantServices;

namespace YnovEat.Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(
            IRestaurantRepository restaurantRepository
        )
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<RestaurantReadDto> GetById(string id)
        {
            var restaurant = await _restaurantRepository.GetById(id);
            return new RestaurantReadDto(restaurant);
        }

        public async Task<RestaurantReadDto> GetByUserId(string currentUserId)
        {
            var restaurant = await _restaurantRepository.GetByUserId(currentUserId);
            if (restaurant == null) throw new NotFoundException();
            return new RestaurantReadDto(restaurant);
        }

        public async Task<RestaurantReadDto> Create(RestaurantCreationDto restaurantCreationDto, CurrentUser user)
        {
            var allRestaurantCategories = await _restaurantRepository.GetAllRestaurantCategories();
            var savedRestaurant =
                await _restaurantRepository.CreateRestaurant(restaurantCreationDto.CreateRestaurant(user, allRestaurantCategories));
            return new RestaurantReadDto(savedRestaurant);
        }

        public async Task<RestaurantReadDto> Update(RestaurantModificationDto restaurantModificationDto,
            Restaurant restaurant)
        {
            var allRestaurantCategories = await _restaurantRepository.GetAllRestaurantCategories();
            var updatedRestaurant = restaurantModificationDto.UpdateRestaurant(restaurant, allRestaurantCategories);
            var savedRestaurant = await _restaurantRepository.UpdateRestaurant(updatedRestaurant);

            return new RestaurantReadDto(savedRestaurant);
        }
    }
}
