using Google_Search_Scraper.WebApi.Models;

namespace Google_Search_Scraper.WebApi.Services;

public interface ISearchScraperService
{
    Task<string> GetUrlPositionsAsync(KeywordAndUrl keywordAndUrl);
}