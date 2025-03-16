using System.ComponentModel.DataAnnotations;

namespace MVCPractise.Models
{
    public class Student
    {
        [Required(ErrorMessage = "ID is required")]
        [Range(1, 9999, ErrorMessage = "ID must be between 1 and 9999")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 50, ErrorMessage = "Name must be between 50 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        public string Faculty { get; set; }
    }
}
