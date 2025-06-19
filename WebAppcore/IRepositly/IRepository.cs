using System.Linq.Expressions;

namespace WebAppcore.IRepositly
{
    public interface IRepository<T> where T : class
    {
        // T  category
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>> filter);
        void Add(T Entity);
        void Delete(T Entity);
		void DeleteRage(IEnumerable<T> Entity);




	}
}
