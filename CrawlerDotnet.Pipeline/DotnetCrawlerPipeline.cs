using CrawlerDotnet.Data.Models;
using CrawlerDotnet.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerDotnet.Pipeline
{
    public class DotnetCrawlerPipeline<T> : IDotnetCrawlerPipeline<T> where T : Entity
    {
        private readonly IGenericRepository<T> _repository;

        public DotnetCrawlerPipeline()
        {
            _repository = new GenericRepository<T>();
        }

        public async Task Run(IEnumerable<T> entityList)
        {
            foreach (var entity in entityList)
            {
                await _repository.CreateAsync(entity);
            }
        }
    }
}