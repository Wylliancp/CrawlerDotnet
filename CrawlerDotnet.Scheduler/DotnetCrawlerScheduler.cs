using System;
using System.Threading.Tasks;

namespace CrawlerDotnet.Scheduler
{
    public class DotnetCrawlerScheduler : IDotnetCrawlerScheduler
    {
        public long RetryTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task Schedule()
        {
            // TODO : Implement Quartz or Hangfire
            throw new NotImplementedException();
        }
    }
}