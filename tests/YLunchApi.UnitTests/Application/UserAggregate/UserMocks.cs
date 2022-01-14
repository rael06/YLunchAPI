using System.Collections.Generic;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.UnitTests.Application.UserAggregate;

public static class UserMocks
{
    public static readonly RestaurantAdminCreateDto RestaurantAdminCreateDto = new()
    {
        Email = "admin@restaurant.com",
        Firstname = "Jean",
        Lastname = "Dupont",
        PhoneNumber = "0612345678",
        Password = "Password1234."
    };

    public static readonly CustomerCreateDto CustomerCreateDto = new()
    {
        Email = "customer@ynov.com",
        Firstname = "Jean",
        Lastname = "Dupont",
        PhoneNumber = "0612345678",
        Password = "Password1234."
    };

    public static UserReadDto CustomerUserReadDto(string id) => new(
        id,
        CustomerCreateDto.Email,
        CustomerCreateDto.PhoneNumber,
        CustomerCreateDto.Firstname,
        CustomerCreateDto.Lastname,
        new List<string> { Roles.Customer }
    );

    public static UserReadDto RestaurantAdminUserReadDto(string id) => new(
        id,
        RestaurantAdminCreateDto.Email,
        RestaurantAdminCreateDto.PhoneNumber,
        RestaurantAdminCreateDto.Firstname,
        RestaurantAdminCreateDto.Lastname,
        new List<string> { Roles.RestaurantAdmin }
    );
}
