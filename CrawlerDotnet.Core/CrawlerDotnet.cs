using CrawlerDotnet.Data.Models;
using CrawlerDotnet.Downloader;
using CrawlerDotnet.Pipeline;
using CrawlerDotnet.Processor;
using CrawlerDotnet.Request;
using CrawlerDotnet.Scheduler;
using System.Threading.Tasks;

namespace CrawlerDotnet.Core
{
    public class DotnetCrawler<T> : ICrawlerDotnet where T : Entity
    {
        public IDotnetCrawlerRequest Request { get; private set; }
        public IDotnetCrawlerDownloader Downloader { get; private set; }
        public IDotnetCrawlerProcessor<T> Processor { get; private set; }
        public IDotnetCrawlerScheduler Scheduler { get; private set; }
        public IDotnetCrawlerPipeline<T> Pipeline { get; private set; }

        public DotnetCrawler()
        {

        }

        public DotnetCrawler<T> AddRequest(IDotnetCrawlerRequest request)
        {
            Request = request;
            return this;
        }

        public DotnetCrawler<T> AddDownloader(IDotnetCrawlerDownloader downloader)
        {
            Downloader = downloader;
            return this;
        }

        public DotnetCrawler<T> AddProcessor(IDotnetCrawlerProcessor<T> processor)
        {
            Processor = processor;
            return this;
        }

        public DotnetCrawler<T> AddScheduler(IDotnetCrawlerScheduler scheduler)
        {
            Scheduler = scheduler;
            return this;
        }

        public DotnetCrawler<T> AddPipeline(IDotnetCrawlerPipeline<T> pipeline)
        {
            Pipeline = pipeline;
            return this;
        }

        public async Task Crawle()
        {
            var linkReader = new DotnetCrawlerPageLinkReader(Request);
            var links = await linkReader.GetLinks(Request.Url, 0);

            foreach (var url in links)
            {
                var document = await Downloader.Download(url);
                var entity = await Processor.Process(document);
                await Pipeline.Run(entity);
            }
        }
    }
}