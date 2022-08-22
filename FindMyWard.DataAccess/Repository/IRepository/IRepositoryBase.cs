
using System.Linq.Expressions;

namespace FindMyWard.DataAccess.Repository.IRepository;

public interface IRepositoryBase<T> where T : class
{
    void Add(T entity);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entity);

    T? GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, string? includeProperties = null);

    T? GetById(int id);
}

