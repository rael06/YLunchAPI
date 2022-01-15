using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using YLunchApi.Domain.UserAggregate.Dto;
using YLunchApi.IntegrationTests.Core.Utils;
using YLunchApi.UnitTests.Application.UserAggregate;

namespace YLunchApi.IntegrationTests.Controllers;

public class TrialsController : TestControllerBase
{
    [Fact]
    public async Task Get_Anonymous_Should_Return_A_200Ok()
    {
        var response = await Client.GetAsync("trials/anonymous");
        Assert.True(response.IsSuccessStatusCode);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await ResponseUtils.DeserializeContentAsync(response);

        content.Should().BeEquivalentTo("YLunchApi is running, you are anonymous");
    }
}
