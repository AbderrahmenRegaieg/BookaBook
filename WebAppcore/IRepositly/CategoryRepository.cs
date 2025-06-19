using System.Data.Entity;
using System.Linq.Expressions;
using WebAppcore.Data;
using WebAppcore.Models;

namespace WebAppcore.IRepositly
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext dbContext): base(dbContext)
		{
			_db = dbContext;
		}
		
		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Category category)
		{
			_db.Categories.Update(category);
		}
	}
}
