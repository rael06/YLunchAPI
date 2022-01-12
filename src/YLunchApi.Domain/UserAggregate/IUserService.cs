using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Domain.UserAggregate;

public interface IUserService
{
    Task<RestaurantOwnerReadDto> Create(RestaurantOwnerCreateDto restaurantOwnerCreateDto);
}
