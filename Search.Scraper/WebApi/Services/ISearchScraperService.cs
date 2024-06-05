using Search.Scraper.WebApi.Models;

namespace Search.Scraper.WebApi.Services;

public interface ISearchScraperService
{
    Task<string> GetUrlPositionsAsync(KeywordAndUrl keywordAndUrl);
}