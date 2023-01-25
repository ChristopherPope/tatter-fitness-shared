using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TatterFitness.Dal.Interfaces.Repositories;

namespace TatterFitness.Dal.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> entities;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public void RemoveAll()
        {
            var entityType = context.Model.FindEntityType(typeof(TEntity));
            if (entityType == null)
            {
                return;
            }

            var tableName = entityType.GetTableName();
            if (tableName == null)
            {
                return;
            }

            var sql = $"Delete from {tableName}";
            context.Database.ExecuteSqlRaw(sql);
        }

        public IEnumerable<TEntity> Read(Expression<Func<TEntity, bool>>? filter = null
            ,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            ,string includeProperties = "")
        {
            IQueryable<TEntity> query = entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity? ReadById(object id)
        {
            return entities.Find(id);
        }

        public virtual TEntity Create(TEntity entity)
        {
            return entities.Add(entity).Entity;
        }

        public virtual void Delete(params TEntity[] entitiesToDelete)
        {
            foreach (var entityToDelete in entitiesToDelete)
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    entities.Attach(entityToDelete);
                }

                entities.Remove(entityToDelete);
            }
        }

        public virtual TEntity Update(TEntity entityToUpdate)
        {
            entities.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;

            return entityToUpdate;
        }

        public bool IsEmpty()
        {
            return (!entities.Any());
        }
    }
}
