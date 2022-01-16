using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using YLunchApi.Main.Controllers;

namespace YLunchApi.UnitTests.Controllers;

public class TrialsControllerTest
{
    private readonly TrialsController _trialsController;

    public TrialsControllerTest()
    {
        _trialsController = new TrialsController();
    }

    [Fact]
    public void Get_Anonymous_Should_Return_A_200Ok()
    {
        // Act
        var response = _trialsController.GetAnonymousTry();

        // Assert
        var responseResult = Assert.IsType<OkObjectResult>(response.Result);
        var responseBody = Assert.IsType<string>(responseResult.Value);

        responseBody.Should().Be("YLunchApi is running, you are anonymous");
    }
}
