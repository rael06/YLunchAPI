using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using YLunchApi.Authentication.Models.Dto;
using YLunchApi.IntegrationTests.Core.Utils;
using YLunchApi.UnitTests.Application.UserAggregate;

namespace YLunchApi.IntegrationTests.Controllers;

public class AuthenticationControllerTest : ControllerTestBase
{
    [Fact]
    public async Task Login_Should_Return_A_200Ok()
    {
        // Wait for UsersControllerTest completion
        await Task.Delay(3000);

        var customerEmail = $"login_should_return_a_200ok{UserMocks.CustomerCreateDto.Email}";
        // Arrange
        var customerCreationRequestBody = new
        {
            Email = customerEmail,
            UserMocks.CustomerCreateDto.Password,
            UserMocks.CustomerCreateDto.PhoneNumber,
            UserMocks.CustomerCreateDto.Lastname,
            UserMocks.CustomerCreateDto.Firstname
        };

        _ = await Client.PostAsJsonAsync("customers", customerCreationRequestBody);

        var customerLoginRequestBody = new
        {
            email = customerEmail,
            UserMocks.CustomerCreateDto.Password
        };

        // Act
        var response = await Client.PostAsJsonAsync("authentication/login", customerLoginRequestBody);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var token = await ResponseUtils.DeserializeContentAsync<TokenReadDto>(response);

    }
}
