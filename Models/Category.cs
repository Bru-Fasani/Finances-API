﻿using System.ComponentModel.DataAnnotations;

namespace Finances_API.Controllers.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
