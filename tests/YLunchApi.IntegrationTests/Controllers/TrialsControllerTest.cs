using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using YLunchApi.Authentication.Models.Dto;
using YLunchApi.IntegrationTests.Core.Utils;
using YLunchApi.UnitTests.Application.UserAggregate;

namespace YLunchApi.IntegrationTests.Controllers;

[Collection("Sequential")]
public class TrialsControllerTest : ControllerTestBase
{
    [Fact]
    public async Task Get_Anonymous_Should_Return_A_200Ok()
    {
        var response = await Client.GetAsync("trials/anonymous");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await ResponseUtils.DeserializeContentAsync(response);

        content.Should().BeEquivalentTo("YLunchApi is running, you are anonymous");
    }

    [Fact]
    public async Task Get_Authenticated_Should_Return_A_200Ok()
    {
        // Arrange
        var applicationSecurityToken = await Authenticate(UserMocks.CustomerCreateDto);

        // Assert
        Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", applicationSecurityToken.AccessToken);
        var authenticatedTrialResponse = await Client.GetAsync("trials/authenticated");
        authenticatedTrialResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var authenticatedTrialResponseContent = await ResponseUtils.DeserializeContentAsync(authenticatedTrialResponse);
        authenticatedTrialResponseContent.Should()
            .BeEquivalentTo(
                $"YLunchApi is running, you are authenticated as {applicationSecurityToken.UserEmail} with Id: {applicationSecurityToken.UserId}");

        var refreshTokensBody = new
        {
            applicationSecurityToken.AccessToken,
            applicationSecurityToken.RefreshToken
        };
        var refreshTokensResponse =
            await Client.PostAsJsonAsync("authentication/refresh-tokens", refreshTokensBody);
        refreshTokensResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var refreshedTokens = await ResponseUtils.DeserializeContentAsync<TokenReadDto>(refreshTokensResponse);

        Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", refreshedTokens.AccessToken);
        var authenticatedTrialRefreshedTokensResponse = await Client.GetAsync("trials/authenticated");
        authenticatedTrialRefreshedTokensResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var authenticatedTrialWithExpiredTokensResponseContent =
            await ResponseUtils.DeserializeContentAsync(authenticatedTrialRefreshedTokensResponse);
        authenticatedTrialWithExpiredTokensResponseContent.Should()
            .BeEquivalentTo(
                $"YLunchApi is running, you are authenticated as {applicationSecurityToken.UserEmail} with Id: {applicationSecurityToken.UserId}");
    }
}
