using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using YLunchApi.Domain.UserAggregate.Dto;
using YLunchApi.IntegrationTests.Core.Utils;
using YLunchApi.UnitTests.Application.UserAggregate;

namespace YLunchApi.IntegrationTests.Controllers;

public class UsersController : ControllerTestBase
{
    [Fact]
    public async Task Post_RestaurantAdmin_Should_Return_A_201Created()
    {
        // Arrange
        var body = new
        {
            UserMocks.RestaurantAdminCreateDto.Email,
            UserMocks.RestaurantAdminCreateDto.Password,
            UserMocks.RestaurantAdminCreateDto.PhoneNumber,
            UserMocks.RestaurantAdminCreateDto.Lastname,
            UserMocks.RestaurantAdminCreateDto.Firstname
        };

        // Act
        var response = await Client.PostAsJsonAsync("restaurant-admins", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var content = await ResponseUtils.DeserializeContentAsync<UserReadDto>(response);
        content.Should().BeEquivalentTo(UserMocks.RestaurantAdminUserReadDto(content.Id));
    }

    [Fact]
    public async Task Post_RestaurantAdmin_Should_Return_A_409Conflict()
    {
        // Arrange
        var body = new
        {
            UserMocks.RestaurantAdminCreateDto.Email,
            UserMocks.RestaurantAdminCreateDto.Password,
            UserMocks.RestaurantAdminCreateDto.PhoneNumber,
            UserMocks.RestaurantAdminCreateDto.Lastname,
            UserMocks.RestaurantAdminCreateDto.Firstname
        };

        // Act
        var response = await Client.PostAsJsonAsync("restaurant-admins", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should().BeEquivalentTo("User already exists");
    }

    [Fact]
    public async Task Post_RestaurantAdmin_Should_Return_A_400BadRequest_When_Fields_Are_Empty()
    {
        // Arrange
        var body = new { };

        // Act
        var response = await Client.PostAsJsonAsync("restaurant-admins", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should().ContainAll(new[]
        {
            "The Email field is required.",
            "The Password field is required.",
            "The Lastname field is required.",
            "The Firstname field is required.",
            "The PhoneNumber field is required."
        });
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("jean.dupont@")]
    [InlineData("jean.dupont@restaurant")]
    [InlineData("jean.dupont@restaurant.c")]
    public async Task Post_RestaurantAdmin_Should_Return_A_400BadRequest_When_Email_Is_Invalid(
        string email
    )
    {
        // Arrange
        var body = new
        {
            Email = email
        };

        // Act
        var response = await Client.PostAsJsonAsync("restaurant-admins", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should().Contain("Email is invalid.");
    }

    [Theory]
    [InlineData("password")]
    [InlineData("password1234")]
    [InlineData("password1234.")]
    [InlineData("Pass12.")]
    public async Task Post_RestaurantAdmin_Should_Return_A_400BadRequest_When_Password_Is_Invalid(
        string password
    )
    {
        // Arrange
        var body = new
        {
            Password = password
        };

        // Act
        var response = await Client.PostAsJsonAsync("restaurant-admins", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should()
            .Contain(
                "Password is not allowed. Must contain at least 8 characters, 1 lowercase letter, 1 uppercase letter, 1 special character and 1 number.");
    }

    [Theory]
    [InlineData("061234567")]
    [InlineData("0512345678")]
    [InlineData("06123456789")]
    [InlineData("07123456789")]
    public async Task Post_RestaurantAdmin_Should_Return_A_400BadRequest_When_PhoneNumber_Is_Invalid(
        string phoneNumber
    )
    {
        // Arrange
        var body = new
        {
            PhoneNumber = phoneNumber
        };

        // Act
        var response = await Client.PostAsJsonAsync("restaurant-admins", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should().Contain("PhoneNumber is not allowed. Example: 0612345678.");
    }

    [Fact]
    public async Task Post_Customer_Should_Return_A_201Created()
    {
        // Arrange
        var body = new
        {
            UserMocks.CustomerCreateDto.Email,
            UserMocks.CustomerCreateDto.Password,
            UserMocks.CustomerCreateDto.PhoneNumber,
            UserMocks.CustomerCreateDto.Lastname,
            UserMocks.CustomerCreateDto.Firstname
        };

        // Act
        var response = await Client.PostAsJsonAsync("customers", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var content = await ResponseUtils.DeserializeContentAsync<UserReadDto>(response);
        content.Should().BeEquivalentTo(UserMocks.CustomerUserReadDto(content.Id));
    }

    [Fact]
    public async Task Post_Customer_Should_Return_A_409Conflict()
    {
        // Arrange
        var body = new
        {
            UserMocks.CustomerCreateDto.Email,
            UserMocks.CustomerCreateDto.Password,
            UserMocks.CustomerCreateDto.PhoneNumber,
            UserMocks.CustomerCreateDto.Lastname,
            UserMocks.CustomerCreateDto.Firstname
        };

        // Act
        _ = await Client.PostAsJsonAsync("customers", body);
        var response = await Client.PostAsJsonAsync("customers", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should().BeEquivalentTo("User already exists");
    }

    [Fact]
    public async Task Post_Customer_Should_Return_A_400BadRequest_When_Fields_Are_Empty()
    {
        // Arrange
        var body = new { };

        // Act
        var response = await Client.PostAsJsonAsync("customers", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should().ContainAll(new[]
        {
            "The Email field is required.",
            "The Password field is required.",
            "The Lastname field is required.",
            "The Firstname field is required.",
            "The PhoneNumber field is required."
        });
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("jean.dupont@")]
    [InlineData("@ynov.com")]
    [InlineData("jean.dupont@ynov.c")]
    public async Task Post_Customer_Should_Return_A_400BadRequest_When_Email_Is_Invalid(
        string email
    )
    {
        // Arrange
        var body = new
        {
            Email = email
        };

        // Act
        var response = await Client.PostAsJsonAsync("customers", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should().Contain("Email is not allowed. You must provide your Ynov email");
    }

    [Theory]
    [InlineData("password")]
    [InlineData("password1234")]
    [InlineData("password1234.")]
    [InlineData("Pass12.")]
    public async Task Post_Customer_Should_Return_A_400BadRequest_When_Password_Is_Invalid(
        string password
    )
    {
        // Arrange
        var body = new
        {
            Password = password
        };

        // Act
        var response = await Client.PostAsJsonAsync("customers", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should()
            .Contain(
                "Password is not allowed. Must contain at least 8 characters, 1 lowercase letter, 1 uppercase letter, 1 special character and 1 number.");
    }

    [Theory]
    [InlineData("061234567")]
    [InlineData("0512345678")]
    [InlineData("06123456789")]
    [InlineData("07123456789")]
    public async Task Post_Customer_Should_Return_A_400BadRequest_When_PhoneNumber_Is_Invalid(
        string phoneNumber
    )
    {
        // Arrange
        var body = new
        {
            PhoneNumber = phoneNumber
        };

        // Act
        var response = await Client.PostAsJsonAsync("customers", body);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var content = await ResponseUtils.DeserializeContentAsync(response);
        content.Should().Contain("PhoneNumber is not allowed. Example: 0612345678.");
    }
}
