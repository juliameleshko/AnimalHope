﻿namespace AnimalHope.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AnimalType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
