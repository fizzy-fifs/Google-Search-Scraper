using Google_Search_Scraper.WebApi.Controllers.Services;
using Google_Search_Scraper.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Google_Search_Scraper.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchScraperController : ControllerBase
{
    private readonly ILogger<SearchScraperController> _logger;
    private readonly SearchScraperService _searchScraperService;
    
    public SearchScraperController(ILogger<SearchScraperController> logger, SearchScraperService searchScraperService)
    {
        _logger = logger;
        _searchScraperService = searchScraperService;
    }

    [HttpPost]
    public async Task<IActionResult> UrlPositionLookup([FromBody] KeywordAndUrl keywordAndUrl)
    {
        var result = await _searchScraperService.GetUrlPositionsAsync(keywordAndUrl);

        return Ok(result);
    }
    
}
