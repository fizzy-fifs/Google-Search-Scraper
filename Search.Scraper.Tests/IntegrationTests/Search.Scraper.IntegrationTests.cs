using System.Net;
using System.Text.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Search.Scraper.WebApi;
using Search.Scraper.WebApi.Models;

namespace Search.Scraper.Tests.IntegrationTests;

public class SearchScraperIntegrationTests: IClassFixture<WebApplicationFactory<ISearchScraperApiMarker>>
{
    private readonly WebApplicationFactory<ISearchScraperApiMarker> _webApplicationFactory;

    public SearchScraperIntegrationTests(WebApplicationFactory<ISearchScraperApiMarker> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task Post_ReturnsOk_WhenRequestIsValid()
    {
        //Arrange
        var client = _webApplicationFactory.CreateClient();
        var keywordAndUrl = new KeywordAndUrl { Keyword = "test", Url = "http://example.com" };
        var content = new StringContent(JsonSerializer.Serialize(keywordAndUrl), System.Text.Encoding.UTF8, "application/json");
        
        //Act
        var response = await client.PostAsync("/url-position-lookup", content);
        var responseContent = await response.Content.ReadAsStringAsync();
        
        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseContent.Should().NotBeNullOrEmpty();
    }
}