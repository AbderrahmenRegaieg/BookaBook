using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Linq.Expressions;
using WebAppcore.Data;
using WebAppcore.IRepositly;
namespace WebAppcore.IRepositly
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;
		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
		}

		public void Add(T Entity)
		{
			dbSet.Add(Entity);
		}

		public void Delete(T Entity)
		{
			dbSet.Remove(Entity);
		}

		public void DeleteRage(IEnumerable<T> Entity)
		{
			dbSet.RemoveRange(Entity);
		}

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;

            // CORRECTED LINE: Assign the result of Where() back to query
            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}
	}
}
