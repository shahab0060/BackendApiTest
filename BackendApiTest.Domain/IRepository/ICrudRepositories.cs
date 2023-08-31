using BackendApiTest.Domain.Entities.Common;

namespace BackendApiTest.Domain.IRepository
{
    public interface ICrudRepository<TEntity, TKey> : IDisposable, IAsyncDisposable
        where TEntity : EntityId<TKey>, IAggregateRoot
        where TKey : struct
    {

    }

    public interface IReadRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
     where TEntity : EntityId<TKey>, IAggregateRoot
     where TKey : struct
    {
        IQueryable<TEntity> GetQuerable();
        Task<IEnumerable<TEntity>> GetList(int skip = 0, int take = 10);
        Task<TEntity?> GetAsNoTracking(TKey id);
    }

    public interface IWriteRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
        where TEntity : EntityId<TKey>, IAggregateRoot
        where TKey : struct
    {
        Task<TEntity?> GetAsTracking(TKey id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        Task SaveChanges();
    }


    public interface IDeleteRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
        where TEntity : EntityId<TKey>, IAggregateRoot
        where TKey : struct
    {
        Task Delete(TKey key);
        void Delete(TEntity entity);
    }

    public interface IUsageRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
  where TEntity : EntityId<TKey>, IAggregateRoot
  where TKey : struct
    {
        Task<bool> IsUsage(TKey key);
    }

}
