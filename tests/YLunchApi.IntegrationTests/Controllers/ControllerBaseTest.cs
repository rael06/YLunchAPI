using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using YLunchApi.IntegrationTests.Core;

namespace YLunchApi.IntegrationTests.Controllers;

public class ControllerBaseTest : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly HttpClient Client;
    protected ControllerBaseTest()
    {
        Client = new CustomWebApplicationFactory<Program>().CreateClient();
        // Client to run tests with online app
        // Client = new HttpClient();

        Client.BaseAddress = new Uri("https://ylunch-api.rael-calitro.ovh/");
    }
}
