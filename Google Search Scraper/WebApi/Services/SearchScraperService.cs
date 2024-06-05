using System.Text.RegularExpressions;
using System.Web;
using Google_Search_Scraper.WebApi.Models;

namespace Google_Search_Scraper.WebApi.Services;

public class SearchScraperService : ISearchScraperService
{
    public SearchScraperService()
    {
    }

    public async Task<string> GetUrlPositionsAsync(KeywordAndUrl keywordAndUrl)
    {
        var encodedKeyword = HttpUtility.UrlEncode(keywordAndUrl.Keyword);

        var client = new HttpClient();
        var searchUrl = $"https://www.google.co.uk/search?num=100&q={encodedKeyword}";
        var html = await client.GetStringAsync(searchUrl);

        var regex = new Regex(@"<a[^>]+href=""/url\?q=(http[s]?://[^""]+)""", RegexOptions.IgnoreCase);
        var matches = regex.Matches(html);

        var urlPositionsInSearchResults = new List<string>();
        
        for (var i=0; i < 100; i++)
        {
            var matchedUrl = matches[i].Groups[1].Value;
            if (matchedUrl.Contains(keywordAndUrl.Url))
            {
                urlPositionsInSearchResults.Add((i + 1).ToString());
            }
        }

        return urlPositionsInSearchResults.Count == 0 ? "0" : string.Join(",", urlPositionsInSearchResults);
    }
}