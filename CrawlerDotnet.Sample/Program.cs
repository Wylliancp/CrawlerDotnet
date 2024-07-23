using CrawlerDotnet.Core;
using CrawlerDotnet.Data.Models;
using CrawlerDotnet.Downloader;
using CrawlerDotnet.Pipeline;
using CrawlerDotnet.Processor;
using CrawlerDotnet.Request;
using System.Threading.Tasks;

namespace CrawlerDotnet.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var crawler = new DotnetCrawler<Catalog>()
                                 .AddRequest(new DotnetCrawlerRequest { Url = "https://www.ebay.com/b/Apple-iPhone/9355/bn_319682", Regex = @".*itm/.+", TimeOut = 5000 })
                                 .AddDownloader(new DotnetCrawlerDownloader { DownloderType = DotnetCrawlerDownloaderType.FromMemory, DownloadPath = @"C:\DotnetCrawlercrawler\" })
                                 .AddProcessor(new DotnetCrawlerProcessor<Catalog> { })
                                 .AddPipeline(new DotnetCrawlerPipeline<Catalog> { });

            await crawler.Crawle();
        }
    }
}