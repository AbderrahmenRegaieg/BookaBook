using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;

namespace WebAppcore.Models
{
    public class Register
    {
        [Key ]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Role { get; set; } //1 admin , 0 user simple

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
