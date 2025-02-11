﻿using System.ComponentModel.DataAnnotations;

namespace ToDoWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PasswordHash { get; set; }
    }
}
