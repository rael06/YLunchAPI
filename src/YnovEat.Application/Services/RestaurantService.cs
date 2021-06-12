using System;
using System.Linq;
using System.Threading.Tasks;
using YnovEat.Application.Exceptions;
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

        public async Task<RestaurantReadDto> Get(string currentUserId)
        {
            var restaurant = await _restaurantRepository.GetByOwnerId(currentUserId);
            if (restaurant == null) throw new NotFoundException();
            return new RestaurantReadDto(restaurant);
        }

        public async Task<RestaurantReadDto> Create(RestaurantCreationDto restaurantCreationDto, CurrentUser user)
        {
            var restaurantId = Guid.NewGuid().ToString();
            var restaurant = new Restaurant
            {
                Id = restaurantId,
                Name = restaurantCreationDto.Name,
                PhoneNumber = restaurantCreationDto.PhoneNumber,
                Email = restaurantCreationDto.Email,
                IsEmailConfirmed = false,
                EmailConfirmationDateTime = null,
                IsOpen = restaurantCreationDto.IsOpen ?? false,
                CreationDateTime = DateTime.Now,
                ZipCode = restaurantCreationDto.ZipCode,
                Country = restaurantCreationDto.Country,
                City = restaurantCreationDto.City,
                StreetNumber = restaurantCreationDto.StreetNumber,
                StreetName = restaurantCreationDto.StreetName,
                AddressExtraInformation = restaurantCreationDto.AddressExtraInformation,
                OwnerId = user.Id,
                Owner = user.RestaurantUser as RestaurantOwner,

                ClosingDates = restaurantCreationDto.ClosingDates.Select(dt => new ClosingDate
                {
                    Id = Guid.NewGuid().ToString(),
                    RestaurantId = restaurantId,
                    ClosingDateTime = dt
                }).ToList(),

                WeekOpeningTimes = restaurantCreationDto.WeekOpeningTimes.Select(day =>
                {
                    var dayOpeningTimesId = Guid.NewGuid().ToString();
                    return new DayOpeningTimes
                    {
                        Id = dayOpeningTimesId,
                        RestaurantId = restaurantId,
                        DayOfWeek = day.DayOfWeek,
                        OpeningTimes = day.OpeningTimes.Select(o => new OpeningTime
                        {
                            Id = Guid.NewGuid().ToString(),
                            DayOpeningTimesId = dayOpeningTimesId,
                            StartTimeInMinutes = o.StartTimeInMinutes,
                            EndTimeInMinutes = o.EndTimeInMinutes,
                            StartOrderTimeInMinutes = o.StartOrderTimeInMinutes,
                            EndOrderTimeInMinutes = o.EndOrderTimeInMinutes
                        }).ToList()
                    };
                }).ToList()
            };

            var savedRestaurant = await _restaurantRepository.CreateRestaurant(restaurant);
            return new RestaurantReadDto(savedRestaurant);
        }

        public async Task<RestaurantReadDto> Update(RestaurantModificationDto restaurantModificationDto,
            Restaurant restaurant)
        {
            restaurant.Name = restaurantModificationDto.Name ?? restaurant.Name;
            restaurant.PhoneNumber = restaurantModificationDto.PhoneNumber ?? restaurant.PhoneNumber;
            restaurant.Email = restaurantModificationDto.Email ?? restaurant.Email;
            restaurant.IsOpen = restaurantModificationDto.IsOpen ?? restaurant.IsOpen;
            restaurant.ZipCode = restaurantModificationDto.ZipCode ?? restaurant.ZipCode;
            restaurant.Country = restaurantModificationDto.Country ?? restaurant.Country;
            restaurant.City = restaurantModificationDto.City ?? restaurant.City;
            restaurant.StreetNumber = restaurantModificationDto.StreetNumber ?? restaurant.StreetNumber;
            restaurant.StreetName = restaurantModificationDto.StreetName ?? restaurant.StreetName;
            restaurant.AddressExtraInformation = restaurantModificationDto.AddressExtraInformation ??
                                                 restaurant.AddressExtraInformation;
            restaurant.LastUpdateDateTime = DateTime.Now;
            restaurant.ClosingDates = restaurantModificationDto.ClosingDates.Select(dt => new ClosingDate
            {
                Id = Guid.NewGuid().ToString(),
                RestaurantId = restaurant.Id,
                ClosingDateTime = dt
            }).ToList();
            restaurant.WeekOpeningTimes = restaurantModificationDto.WeekOpeningTimes.Select(day =>
            {
                var dayOpeningTimesId = Guid.NewGuid().ToString();
                return new DayOpeningTimes
                {
                    Id = dayOpeningTimesId,
                    RestaurantId = restaurant.Id,
                    DayOfWeek = day.DayOfWeek,
                    OpeningTimes = day.OpeningTimes.Select(o => new OpeningTime
                    {
                        Id = Guid.NewGuid().ToString(),
                        DayOpeningTimesId = dayOpeningTimesId,
                        StartTimeInMinutes = o.StartTimeInMinutes,
                        EndTimeInMinutes = o.EndTimeInMinutes,
                        StartOrderTimeInMinutes = o.StartOrderTimeInMinutes,
                        EndOrderTimeInMinutes = o.EndOrderTimeInMinutes
                    }).ToList()
                };
            }).ToList();

            var savedRestaurant = await _restaurantRepository.UpdateRestaurant(restaurant);

            return new RestaurantReadDto(savedRestaurant);
        }
    }
}
