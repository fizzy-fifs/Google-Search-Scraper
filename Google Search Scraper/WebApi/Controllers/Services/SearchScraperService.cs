using System.Text.RegularExpressions;
using System.Web;
using Google_Search_Scraper.WebApi.Models;

namespace Google_Search_Scraper.WebApi.Controllers.Services;

public class SearchScraperService : ISearchScraperService
{
    public SearchScraperService()
    {
    }

    public async Task<IEnumerable<string>> GetUrlPositionsAsync(KeywordAndUrl keywordAndUrl)
    {
        var encodedKeyword = HttpUtility.UrlEncode(keywordAndUrl.Keyword);
        
        var client = new HttpClient();
        var searchUrl = $"https://www.google.co.uk/search?num=100&q={encodedKeyword}";
        var html = await client.GetStringAsync(searchUrl);
        
        //div id = search >> div class= MjjYud >> span jscontroller = msmzHf

        var searchResultUrl = new List<string>();
        
        var regex = new Regex(@"<div class=""""MjjYud"""">.*?<a\s+href=""""(?<url>.*?)"""".*?>");
        var matches = regex.Matches(html);

        foreach (Match match in matches)
        {
            searchResultUrl.Add(match.Groups["url"].Value);
        }
        
        Console.WriteLine($"Search Results Url List: {searchResultUrl}" );
        Console.WriteLine($"Matches: {matches}");

        return searchResultUrl;
    }
}