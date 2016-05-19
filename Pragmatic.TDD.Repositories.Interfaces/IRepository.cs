using System.Linq;

namespace Pragmatic.TDD.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        T Get<TKey>(TKey id);
        IQueryable<T> GetAll();
    }
}
