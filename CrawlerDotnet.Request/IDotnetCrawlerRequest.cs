

namespace CrawlerDotnet.Request
{
    public interface IDotnetCrawlerRequest
    {
        string Url { get; set; }
        string Regex { get; set; }
        long TimeOut { get; set; }
    }
}
