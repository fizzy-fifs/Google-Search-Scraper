using Microsoft.AspNetCore.Mvc;
using Search.Scraper.WebApi.Models;
using Search.Scraper.WebApi.Services;

namespace Search.Scraper.WebApi.Controllers;

[ApiController]
[Route("url-position-lookup")]
public class SearchScraperController : ControllerBase
{
    private readonly ISearchScraperService _searchScraperService;
    
    public SearchScraperController(ISearchScraperService searchScraperService)
    {
        _searchScraperService = searchScraperService;
    }

    [HttpPost]
    public async Task<IActionResult> UrlPositionLookup([FromBody] KeywordAndUrl keywordAndUrl)
    {
        var result = await _searchScraperService.GetUrlPositionsAsync(keywordAndUrl);

        return Ok(result);
    }
    
}
