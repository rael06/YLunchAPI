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

        public async Task Create(RestaurantCreationDto restaurantCreationDto, CurrentUser user)
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

            await _restaurantRepository.CreateRestaurant(restaurant);
        }
    }
}
