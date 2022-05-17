using ExpiryLogger.DataAccessLayer.Entities;

namespace ExpiryLogger.DataAccessLayer.Repositories;

public interface IRepository<T> where T : IEntity
{
	// create
	int Add(T entity);
	int Add(IEnumerable<T> entities);

	// read
	T? Get(int id);
	IEnumerable<T>? Get(Func<T, bool> predicate);
	IEnumerable<T>? Get();
	T GetFirst();
	T GetFirst(Func<T, bool> predicate);
	T? GetFirstOrDefault();
	T? GetFirstOrDefault(Func<T, bool> predicate);

	// update
	int Update(T entity);
	int Update(IEnumerable<T> entities);

	// delete
	int Delete(int id);
	int Delete(IEnumerable<T> entities);
	int Delete(T entity);
	int Delete(Func<T, bool> predicate);
	int Delete();
}
