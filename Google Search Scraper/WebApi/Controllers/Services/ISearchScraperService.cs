using Google_Search_Scraper.WebApi.Models;

namespace Google_Search_Scraper.WebApi.Controllers.Services;

public interface ISearchScraperService
{
    Task<IEnumerable<string>> GetUrlPositionsAsync(KeywordAndUrl keywordAndUrl);
}