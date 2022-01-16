using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using YLunchApi.Application.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;
using YLunchApi.Infrastructure.Database.Repositories;
using YLunchApi.Main.Controllers;
using YLunchApi.UnitTests.Application.UserAggregate;
using YLunchApi.UnitTests.Core;

namespace YLunchApi.UnitTests.Controllers;

public class AuthenticationControllerTest
{
    private readonly AuthenticationController _authenticationController;

    public AuthenticationControllerTest()
    {
        _authenticationController = new AuthenticationController();
    }

    [Fact]
    public void Get_Anonymous_Should_Return_A_200Ok()
    {
        // Arrange
        var loginRequestDto = new LoginRequestDto
        {
            Email = UserMocks.RestaurantAdminCreateDto.Email,
            Password = UserMocks.RestaurantAdminCreateDto.Password
        };

        // Act
        // ActionResult<TokensDto> response = _authenticationController.Login(loginRequestDto);
    }
}
