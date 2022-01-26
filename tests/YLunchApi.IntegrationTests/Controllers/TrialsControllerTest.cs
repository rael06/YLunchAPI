using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using YLunchApi.IntegrationTests.Core.Utils;

namespace YLunchApi.IntegrationTests.Controllers;

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
}