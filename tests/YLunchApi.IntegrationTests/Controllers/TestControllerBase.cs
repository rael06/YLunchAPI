using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using YLunchApi.IntegrationTests.Core;

namespace YLunchApi.IntegrationTests.Controllers;

public class TestControllerBase : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly HttpClient Client;
    protected TestControllerBase()
    {
        Client = new CustomWebApplicationFactory<Program>().CreateClient();
    }
}
