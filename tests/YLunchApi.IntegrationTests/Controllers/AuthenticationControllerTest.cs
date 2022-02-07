using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using YLunchApi.Authentication.Models.Dto;
using YLunchApi.Domain.UserAggregate.Dto;
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

        var email = $"login_should_return_a_200ok_{UserMocks.CustomerCreateDto.Email}";
        // Arrange
        var customerCreationRequestBody = new
        {
            Email = email,
            UserMocks.CustomerCreateDto.Password,
            UserMocks.CustomerCreateDto.PhoneNumber,
            UserMocks.CustomerCreateDto.Lastname,
            UserMocks.CustomerCreateDto.Firstname
        };

        var customerCreationResponse = await Client.PostAsJsonAsync("customers", customerCreationRequestBody);
        var customerCreationResponseContent =
            await ResponseUtils.DeserializeContentAsync<UserReadDto>(customerCreationResponse);
        Assert.IsType<string>(customerCreationResponseContent.Id);
        Assert.IsType<string>(customerCreationResponseContent.Email);
        var customerId = customerCreationResponseContent.Id;
        var customerEmail = customerCreationResponseContent.Email;

        var customerLoginRequestBody = new
        {
            email = customerEmail,
            UserMocks.CustomerCreateDto.Password
        };

        // Act
        var loginResponse = await Client.PostAsJsonAsync("authentication/login", customerLoginRequestBody);
        loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var tokens = await ResponseUtils.DeserializeContentAsync<TokenReadDto>(loginResponse);

        // Assert
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
        var authenticatedTrialResponse = await Client.GetAsync("trials/authenticated");
        authenticatedTrialResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var authenticatedTrialResponseContent = await ResponseUtils.DeserializeContentAsync(authenticatedTrialResponse);
        authenticatedTrialResponseContent.Should()
            .BeEquivalentTo($"YLunchApi is running, you are authenticated as {customerEmail} with Id: {customerId}");

        var refreshTokensResponse = await Client.PostAsJsonAsync("authentication/refresh-tokens", tokens);
        refreshTokensResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var refreshedTokens = await ResponseUtils.DeserializeContentAsync<TokenReadDto>(refreshTokensResponse);

        Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", refreshedTokens.AccessToken);
        var authenticatedTrialRefreshedTokensResponse = await Client.GetAsync("trials/authenticated");
        authenticatedTrialRefreshedTokensResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var authenticatedTrialWithExpiredTokensResponseContent =
            await ResponseUtils.DeserializeContentAsync(authenticatedTrialRefreshedTokensResponse);
        authenticatedTrialWithExpiredTokensResponseContent.Should()
            .BeEquivalentTo($"YLunchApi is running, you are authenticated as {customerEmail} with Id: {customerId}");
    }
}
