using CrawlerDotnet.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlerDotnet.Data.Repository
{
    public interface IGenericRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task CreateAsync(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
