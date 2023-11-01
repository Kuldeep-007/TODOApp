using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TODOApp.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Delete(int id);
        Task Upsert(T entity);
        Task Save();
    }
}
