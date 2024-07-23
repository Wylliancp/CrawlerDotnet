using CrawlerDotnet.Data.Models;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerDotnet.Processor
{
    public interface IDotnetCrawlerProcessor<T> where T : Entity
    {
        Task<IEnumerable<T>> Process(HtmlDocument document);
    }
}
