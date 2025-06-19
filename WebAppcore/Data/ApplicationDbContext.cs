using Microsoft.EntityFrameworkCore;
using WebAppcore.Models;

namespace WebAppcore.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Produits { get; set; }
		public DbSet<Register> Users { get; set; }
		public DbSet<CommandClient> Commands { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder); // Important for Identity configuration

			// Seed Categories
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
				new Category { Id = 2, Name = "History", DisplayOrder = 2 },
				new Category { Id = 3, Name = "Scfi", DisplayOrder = 3 }
			);

			// Seed Products
			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Reference = "PROD001",
					Path = "product1.jpg",
					Prix = 19.99f,
					Qte = 100,
					CategoryId = 1
				}
			// Add more products as needed
			);

			// Seed Register (Note: Consider using IdentityUser instead of custom Register for seeding)
			/* modelBuilder.Entity<Register>().HasData(
                new Register { Id = 1, Role = 1, DateNaissance = DateTime.Today, Email = "Abdou@gmail.com", Name = "Abdou", Password = "Admin", ConfirmPassword = "Admin" }
            ); */

			// Seed CommandClient (using ProductReference for the relationship)
			/* modelBuilder.Entity<CommandClient>().HasData(
                new CommandClient
                {
                    Id = 1,
                    OrderDate = DateTime.Now,
                    OrderedQuantity = 5,
                    ProductReference = "poor man",
                    TotalPrice = 99.95f 
                }
            ); */
		}
	}
}