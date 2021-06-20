using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YnovEat.Application.Exceptions;
using YnovEat.Domain.DTO.OrderModels;
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

        public async Task<ICollection<RestaurantReadDto>> GetAllForCustomer()
        {
            var restaurants = await _restaurantRepository.GetAllForCustomer();
            return restaurants.Select(x => new RestaurantReadDto(x)).ToList();
        }

        public async Task<ICollection<RestaurantReadDto>> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAll();
            return restaurants.Select(x => new RestaurantReadDto(x)).ToList();
        }

        public async Task<ICollection<OrderReadDto>> GetTodayOrders(string restaurantId)
        {
            var orders = await _restaurantRepository.GetOrdersByRestaurantId(restaurantId);
            return orders.Select(x => new OrderReadDto(x)).ToList();
        }

        public async Task<RestaurantReadDto> Create(RestaurantCreationDto restaurantCreationDto, CurrentUser user)
        {
            var allRestaurantCategories = await _restaurantRepository.GetAllRestaurantCategories();
            var savedRestaurant =
                await _restaurantRepository.CreateRestaurant(Restaurant.Create(restaurantCreationDto, user,
                    allRestaurantCategories));
            return new RestaurantReadDto(savedRestaurant);
        }

        public async Task<RestaurantReadDto> Update(RestaurantModificationDto restaurantModificationDto,
            Restaurant restaurant)
        {
            var allRestaurantCategories = await _restaurantRepository.GetAllRestaurantCategories();
            restaurant.Update(restaurantModificationDto, allRestaurantCategories);
            var savedRestaurant = await _restaurantRepository.UpdateRestaurant(restaurant);

            return new RestaurantReadDto(savedRestaurant);
        }
    }
}
