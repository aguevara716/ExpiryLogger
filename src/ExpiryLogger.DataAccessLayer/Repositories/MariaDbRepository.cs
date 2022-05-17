using ExpiryLogger.DataAccessLayer.Entities;

namespace ExpiryLogger.DataAccessLayer.Repositories
{
    public class MariaDbRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly ExpirationLoggerContext _dbContext;

        public MariaDbRepository(ExpirationLoggerContext dbContext)
        {
            _dbContext = dbContext;
        }

        // create
        public int Add(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _ = _dbContext.Add(entity);
            var rowsInserted = _dbContext.SaveChanges();
            return rowsInserted;
        }

        public int Add(IEnumerable<T> entities)
        {
            ArgumentNullException.ThrowIfNull(entities);
            if (!entities.Any())
                throw new ArgumentNullException(nameof(entities));

            _dbContext.AddRange(entities);
            var rowsInserted = _dbContext.SaveChanges();
            return rowsInserted;
        }

        // read
        public T? Get(int id)
        {
            var entity = _dbContext.Set<T>().FirstOrDefault(e => e.Id == id);
            return entity;
        }

        public IEnumerable<T>? Get(Func<T, bool> predicate)
        {
            var entities = _dbContext.Set<T>().Where(predicate);
            return entities;
        }

        public IEnumerable<T>? Get()
        {
            var entities = _dbContext.Set<T>();
            return entities;
        }

        public T GetFirst()
        {
            var entity = _dbContext.Set<T>().First();
            return entity;
        }

        public T GetFirst(Func<T, bool> predicate)
        {
            var entity = _dbContext.Set<T>().First(predicate);
            return entity;
        }

        public T? GetFirstOrDefault()
        {
            var entity = _dbContext.Set<T>().FirstOrDefault();
            return entity;
        }

        public T? GetFirstOrDefault(Func<T, bool> predicate)
        {
            var entity = _dbContext.Set<T>().FirstOrDefault(predicate);
            return entity;
        }

        // update
        public int Update(T entity)
        {
            _ = _dbContext.Set<T>().Update(entity);
            var rowsUpdated = _dbContext.SaveChanges();
            return rowsUpdated;
        }

        public int Update(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            var rowsUpdated = _dbContext.SaveChanges();
            return rowsUpdated;
        }

        // delete
        public int Delete(int id)
        {
            var entity = Get(id);
            if (entity is null)
                return 0;
            return Delete(entity);
        }

        public int Delete(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            var rowsDeleted = _dbContext.SaveChanges();
            return rowsDeleted;
        }

        public int Delete(T entity)
        {
            _ = _dbContext.Set<T>().Remove(entity);
            var rowsDeleted = _dbContext.SaveChanges();
            return rowsDeleted;
        }

        public int Delete(Func<T, bool> predicate)
        {
            var entities = Get(predicate);
            if (entities is null || !entities.Any())
                return 0;

            return Delete(entities);
        }

        public int Delete()
        {
            var entities = Get();
            if (entities is null || !entities.Any())
                return 0;
            
            return Delete(entities);
        }
    }
}

