using WebAppcore.Models;

namespace WebAppcore.IRepositly
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update (Category category);
		void Save();
	}
}
