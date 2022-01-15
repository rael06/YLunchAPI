using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using YLunchApi.Domain.UserAggregate.Dto;
using YLunchApi.IntegrationTests.Core;
using YLunchApi.IntegrationTests.Core.Utils;
using YLunchApi.UnitTests.Application.UserAggregate;

namespace YLunchApi.IntegrationTests.Controllers;

public class UsersController : TestControllerBase
{
    [Fact]
    public async Task Post_RestaurantAdmin_Should_Return_A_201Created()
    {
        var response = await Client.PostAsJsonAsync("restaurant-admins", UserMocks.RestaurantAdminCreateDto);
        Assert.True(response.IsSuccessStatusCode);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var content = await ResponseUtils.DeserializeContentAsync<UserReadDto>(response);

        content.Should().BeEquivalentTo(UserMocks.RestaurantAdminUserReadDto(content.Id));
    }
}
