using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using YLunchApi.Authentication.Models;
using YLunchApi.Authentication.Models.Dto;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;
using YLunchApi.IntegrationTests.Core;
using YLunchApi.IntegrationTests.Core.Utils;

namespace YLunchApi.IntegrationTests.Controllers;

public abstract class ControllerTestBase : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly HttpClient Client;

    protected ControllerTestBase()
    {
        var webApplication = new CustomWebApplicationFactory<Program>();
        Client = webApplication.CreateClient();
    }

    protected async Task<ApplicationSecurityToken> Authenticate(CustomerCreateDto customerCreateDto)
    {
        // Arrange
        var customerCreationRequestBody = new
        {
            customerCreateDto.Email,
            customerCreateDto.Password,
            customerCreateDto.PhoneNumber,
            customerCreateDto.Lastname,
            customerCreateDto.Firstname
        };

        var customerCreationResponse = await Client.PostAsJsonAsync("customers", customerCreationRequestBody);
        var customerCreationResponseContent =
            await ResponseUtils.DeserializeContentAsync<UserReadDto>(customerCreationResponse);
        Assert.IsType<string>(customerCreationResponseContent.Email);
        var customerEmail = customerCreationResponseContent.Email;

        var customerLoginRequestBody = new
        {
            email = customerEmail,
            customerCreateDto.Password
        };

        // Act
        var loginResponse = await Client.PostAsJsonAsync("authentication/login", customerLoginRequestBody);

        // Assert
        loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var tokens = await ResponseUtils.DeserializeContentAsync<TokenReadDto>(loginResponse);
        Assert.IsType<string>(tokens.AccessToken);
        Assert.IsType<string>(tokens.RefreshToken);
        var applicationSecurityToken = new ApplicationSecurityToken(tokens.AccessToken, tokens.RefreshToken);
        applicationSecurityToken.UserEmail.Should().Be(customerCreateDto.Email);
        applicationSecurityToken.UserRoles.Should().BeEquivalentTo(new List<string> { Roles.Customer });
        return applicationSecurityToken;
    }
}
