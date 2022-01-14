using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using YLunchApi.Application.UserAggregate;
using YLunchApi.Domain.Exceptions;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;
using YLunchApi.Infrastructure.Database.Repositories;
using YLunchApi.UnitTests.Core;

namespace YLunchApi.UnitTests.Application.UserAggregate;

public class UserServiceTest
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public UserServiceTest()
    {
        var context = ContextBuilder.BuildContext();
        var userManagerMock = ManagerMocker.GetUserManagerMock(context);
        var roleManagerMock = ManagerMocker.GetRoleManagerMock(context);
        _userRepository = new UserRepository(context, userManagerMock.Object, roleManagerMock.Object);
        _userService = new UserService(_userRepository);
    }

    [Fact]
    public async Task Should_Create_RestaurantAdmin()
    {
        // Arrange
        var userCreateDto = new RestaurantAdminCreateDto
        {
            Email = "admin@restaurant.com",
            Firstname = "Jean",
            Lastname = "Dupont",
            PhoneNumber = "0612345678",
            Password = "Password1234."
        };

        // Act
        var actual = await _userService.Create(userCreateDto, Roles.RestaurantAdmin);
        var userDb = await _userRepository.GetByEmail(userCreateDto.Email);
        userDb.Should().NotBeNull();
        var expected = new UserReadDto(userDb!, new List<string> { Roles.RestaurantAdmin });

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task Should_Create_Customer()
    {
        // Arrange
        var userCreateDto = new CustomerCreateDto
        {
            Email = "customer@ynov.com",
            Firstname = "Jean",
            Lastname = "Dupont",
            PhoneNumber = "0612345678",
            Password = "Password1234."
        };

        // Act
        var actual = await _userService.Create(userCreateDto, Roles.Customer);
        var userDb = await _userRepository.GetByEmail(userCreateDto.Email);
        userDb.Should().NotBeNull();
        var expected = new UserReadDto(userDb!, new List<string> { Roles.Customer });

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task Should_Throw_Entity_Already_Exists_Exception()
    {
        // Arrange
        var userCreateDto = new CustomerCreateDto
        {
            Email = "customer@ynov.com",
            Firstname = "Jean",
            Lastname = "Dupont",
            PhoneNumber = "0612345678",
            Password = "Password1234."
        };
        await _userService.Create(userCreateDto, Roles.Customer);

        // Act
        async Task Act() => await _userService.Create(userCreateDto, Roles.Customer);

        // Assert
        await Assert.ThrowsAsync<EntityAlreadyExistsException>(Act);
    }
}
