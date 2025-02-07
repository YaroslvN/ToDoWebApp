using System.ComponentModel.DataAnnotations;

namespace ToDoWebApp.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
