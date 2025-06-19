using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppcore.Models
{
    public class CommandClient
    {
        [Key]
        public int Id { get; set; }
        public string ProductReference { get; set; } = null!; // Foreign key to Product
        public int OrderedQuantity { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("ProductReference")]
        public Product Product { get; set; } = null!;
    }
}