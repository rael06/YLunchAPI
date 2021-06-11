using System;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.RestaurantModels;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
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

        public async Task<RestaurantReadDto> Create(RestaurantCreationDto restaurantCreationDto, CurrentUser user)
        {
            var restaurant = new Restaurant
            {
                Id = Guid.NewGuid().ToString(),
                Name = restaurantCreationDto.Name,
                PhoneNumber = restaurantCreationDto.PhoneNumber,
                Email = restaurantCreationDto.Email,
                IsEmailConfirmed = false,
                EmailConfirmationDateTime = null,
                OrderLimitTimeInMinutes = restaurantCreationDto.OrderLimitTimeInMinutes,
                IsOpen = restaurantCreationDto.IsOpen ?? false,
                CreationDateTime = DateTime.Now,
                ZipCode = restaurantCreationDto.ZipCode,
                Country = restaurantCreationDto.Country,
                City = restaurantCreationDto.City,
                StreetNumber = restaurantCreationDto.StreetNumber,
                StreetName = restaurantCreationDto.StreetName,
                AddressExtraInformation = restaurantCreationDto.AddressExtraInformation,
                OwnerId = user.Id,
                Owner = user.RestaurantUser as RestaurantOwner
            };

            var savedRestaurant = await _restaurantRepository.CreateRestaurant(restaurant);
            return new RestaurantReadDto(savedRestaurant);
        }

        public async Task<RestaurantReadDto> Update(RestaurantModificationDto restaurantModificationDto)
        {
            var restaurant = await _restaurantRepository.GetById(restaurantModificationDto.Id);

            restaurant.Name = restaurantModificationDto.Name ?? restaurant.Name;
            restaurant.PhoneNumber = restaurantModificationDto.PhoneNumber ?? restaurant.PhoneNumber;
            restaurant.Email = restaurantModificationDto.Email ?? restaurant.Email;
            restaurant.OrderLimitTimeInMinutes = restaurantModificationDto.OrderLimitTimeInMinutes ?? restaurant.OrderLimitTimeInMinutes;
            restaurant.IsOpen = restaurantModificationDto.IsOpen ?? restaurant.IsOpen;
            restaurant.ZipCode = restaurantModificationDto.ZipCode ?? restaurant.ZipCode;
            restaurant.Country = restaurantModificationDto.Country ?? restaurant.Country;
            restaurant.City = restaurantModificationDto.City ?? restaurant.City;
            restaurant.StreetNumber = restaurantModificationDto.StreetNumber ?? restaurant.StreetNumber;
            restaurant.StreetName = restaurantModificationDto.StreetName ?? restaurant.StreetName;
            restaurant.AddressExtraInformation = restaurantModificationDto.AddressExtraInformation ?? restaurant.AddressExtraInformation;

            var savedRestaurant = await _restaurantRepository.UpdateRestaurant(restaurant);
            return new RestaurantReadDto(savedRestaurant);
        }
    }
}
