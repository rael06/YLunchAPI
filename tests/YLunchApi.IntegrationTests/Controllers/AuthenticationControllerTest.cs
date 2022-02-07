using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using YLunchApi.Authentication.Models.Dto;
using YLunchApi.IntegrationTests.Core.Utils;
using YLunchApi.UnitTests.Application.UserAggregate;

namespace YLunchApi.IntegrationTests.Controllers;

[Collection("Sequential")]
public class AuthenticationControllerTest : ControllerTestBase
{
    [Fact]
    public async Task Login_Should_Return_A_200Ok()
    {
        // Arrange, Act and Assert
        _ = await Authenticate(UserMocks.CustomerCreateDto);
    }

    [Fact]
    public async Task Refresh_Tokens_Should_Return_A_200Ok()
    {
        // Arrange
        var applicationSecurityToken = await Authenticate(UserMocks.CustomerCreateDto);

        var refreshTokensBody = new
        {
            applicationSecurityToken.AccessToken,
            applicationSecurityToken.RefreshToken
        };

        // Act
        var refreshTokensResponse = await Client.PostAsJsonAsync("authentication/refresh-tokens", refreshTokensBody);
        refreshTokensResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var refreshedTokens = await ResponseUtils.DeserializeContentAsync<TokenReadDto>(refreshTokensResponse);

        // Assert
        Assert.IsType<string>(refreshedTokens.AccessToken);
        Assert.IsType<string>(refreshedTokens.RefreshToken);
    }
}
