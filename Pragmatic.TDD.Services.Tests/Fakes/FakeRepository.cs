using System.Collections.Generic;
using System.Linq;
using Pragmatic.TDD.Repositories.Interfaces;

namespace Pragmatic.TDD.Services.Tests.Fakes
{
    /// <summary>
    /// Fake Repository for testing purposes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDataContextBase"></typeparam>
    public class FakeRepository<T, TDataContextBase> : IRepository<T> where TDataContextBase : FakeDataContextBase
    {
        /// <summary>
        /// The Context
        /// </summary>
        protected TDataContextBase Context { get; set; }

        /// <summary>
        /// The data in the context
        /// </summary>
        private IList<T> _data;
        public IList<T> Data
        {
            get
            {
                var get =
                    Context.GetType().GetProperties().First(x => x.PropertyType == typeof(IList<T>)).GetMethod;

                _data = (List<T>)get.Invoke(Context, null);

                return _data;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public FakeRepository(TDataContextBase context)
        {
            Context = context;
        }

        /// <summary>
        /// Get all of type from the context
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return Data.AsQueryable();
        }

        /// <summary>
        /// Get a specific entity from the context
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get<TKey>(TKey id)
        {
            foreach (var entity in Data)
            {
                if (EntityFound(id, entity))
                {
                    return entity;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Check if entity found in the collection
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static bool EntityFound<TKey>(TKey id, T entity)
        {
            return typeof(T).GetProperties()
                .Any(
                    x =>
                        x.PropertyType == typeof(TKey)
                        && x.GetValue(entity, null).Equals(id));
        }
    }

    public class FakeRepository<T> : FakeRepository<T, FakeDataContext>
    {
        public FakeRepository(FakeDataContext context) : base(context) { }
    }
}