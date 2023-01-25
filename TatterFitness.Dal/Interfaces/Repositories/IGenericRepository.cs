using System.Linq.Expressions;

namespace TatterFitness.Dal.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Read(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");
        TEntity? ReadById(object id);
        TEntity Create(TEntity entity);
        void Delete(params TEntity[] entitiesToDelete);
        TEntity Update(TEntity entityToUpdate);
        void RemoveAll();
        bool IsEmpty();
    }
}
