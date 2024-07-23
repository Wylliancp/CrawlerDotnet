using CrawlerDotnet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerDotnet.Pipeline
{
    public interface IDotnetCrawlerPipeline<T> where T : Entity
    {
        Task Run(IEnumerable<T> entity);
    }
}
