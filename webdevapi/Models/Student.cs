using System.ComponentModel.DataAnnotations;

namespace webdevapi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(16, 100)]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
