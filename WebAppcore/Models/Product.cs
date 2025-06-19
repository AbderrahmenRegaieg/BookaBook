using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppcore.Models
{
	public class Product
	{
		[Key]
		public String Reference { get; set; }
		public String Path { get; set; }

		public float Prix { get; set; }
		public int Qte { get; set; }
		// Clé étrangère
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		// Navigation vers la catégorie
		[ForeignKey("CategoryId")]
		public Category? Category { get; set; }

       
    }
}
