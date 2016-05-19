using System.Data.Entity;
using System.Linq;
using Pragmatic.TDD.Repositories.Interfaces;

namespace Pragmatic.TDD.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public T Get<TKey>(TKey id)
        {
            var task = DbSet.FindAsync(id);

            return task.Result;
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
    }
}
