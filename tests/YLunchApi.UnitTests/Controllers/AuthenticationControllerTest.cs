using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSubstitute;
using Xunit;
using YLunchApi.Application.UserAggregate;
using YLunchApi.Authentication.Models;
using YLunchApi.Authentication.Services;
using YLunchApi.AuthenticationShared.Repositories;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;
using YLunchApi.Infrastructure.Database;
using YLunchApi.Infrastructure.Database.Repositories;
using YLunchApi.Main.Controllers;
using YLunchApi.UnitTests.Application.UserAggregate;
using YLunchApi.UnitTests.Core;

namespace YLunchApi.UnitTests.Controllers;

public class AuthenticationControllerTest
{
    private readonly AuthenticationController _authenticationController;
    private readonly UserService _userService;
    private readonly ApplicationDbContext _context;

    public AuthenticationControllerTest()
    {
        _context = ContextBuilder.BuildContext();

        var roleManagerMock = ManagerMocker.GetRoleManagerMock(_context);
        var userManagerMock = ManagerMocker.GetUserManagerMock(_context);

        var userRepository = new UserRepository(_context, userManagerMock.Object, roleManagerMock.Object);
        _userService = new UserService(userRepository);

        const string jwtSecret = "JsonWebTokenSecretForTests";
        var optionsMonitorMock = Substitute.For<IOptionsMonitor<JwtConfig>>();
        optionsMonitorMock.CurrentValue.Returns(new JwtConfig
        {
            Secret = jwtSecret
        });

        var key = Encoding.ASCII.GetBytes(jwtSecret);

        var tokenValidationParameter = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            RequireExpirationTime = false,

            // Allow to use seconds for expiration of token
            // Required only when token lifetime less than 5 minutes
            ClockSkew = TimeSpan.Zero
        };

        var jwtService = new JwtService(
            userManagerMock.Object,
            new RefreshTokenRepository(_context),
            optionsMonitorMock,
            tokenValidationParameter
        );
            _authenticationController = new AuthenticationController(jwtService, _userService);
    }

    [Fact]
    public async Task Login_Should_Return_A_200Ok_Containing_Tokens()
    {
        // Arrange
        await _userService.Create(UserMocks.RestaurantAdminCreateDto, Roles.RestaurantAdmin);
        var loginRequestDto = new LoginRequestDto
        {
            Email = UserMocks.RestaurantAdminCreateDto.Email,
            Password = UserMocks.RestaurantAdminCreateDto.Password
        };

        // Act
        var response = await _authenticationController.Login(loginRequestDto);
    }
}
