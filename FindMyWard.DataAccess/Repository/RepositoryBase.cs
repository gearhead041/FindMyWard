using FindMyWard.DataAccess.Data;
using FindMyWard.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FindMyWard.DataAccess.Repository
{
    public class Repository<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, string? includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            if (orderby != null)
                return orderby(query).ToList();

            return query.ToList();
        }

        public T? GetById(int id)
            => _context.Set<T>().Find(id);

        public T? GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            foreach (var item in entity)
            {
                _context.Set<T>().Remove(item);
            }
        }
    }
}
