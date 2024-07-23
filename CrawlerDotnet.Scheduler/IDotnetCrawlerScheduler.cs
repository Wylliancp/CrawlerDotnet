using System.Threading.Tasks;

namespace CrawlerDotnet.Scheduler
{
    public interface IDotnetCrawlerScheduler
    {
        long RetryTime { get; set; }
        Task Schedule();
    }
}
