using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;
using Google_Search_Scraper.WebApi.Models;

namespace Google_Search_Scraper.WebApi.Services;

public class SearchScraperService : ISearchScraperService
{
    public async Task<string> GetUrlPositionsAsync(KeywordAndUrl keywordAndUrl)
    {
        var html = await FetchHtmlAsync(keywordAndUrl.Keyword);

        var regex = new Regex(@"<a[^>]+href=""/url\?q=(http[s]?://[^""]+)""", RegexOptions.IgnoreCase);
        var matches = regex.Matches(html);

        var urlPositionsInSearchResults = new List<string>();

        for (var i = 0; i < 100; i++)
        {
            var matchedUrl = matches[i].Groups[1].Value;
            if (matchedUrl.Contains(keywordAndUrl.Url))
            {
                urlPositionsInSearchResults.Add((i + 1).ToString());
            }
        }

        return urlPositionsInSearchResults.Count == 0 ? "0" : JsonSerializer.Serialize(string.Join(",", urlPositionsInSearchResults));
    }

    private static async Task<string> FetchHtmlAsync(string keyword)
    {
        var encodedKeyword = HttpUtility.UrlEncode(keyword);
        var searchUrl = $"https://www.google.co.uk/search?num=100&q={encodedKeyword}";

        var client = new HttpClient();
        var html = await client.GetStringAsync(searchUrl);

        return html;
    }
}