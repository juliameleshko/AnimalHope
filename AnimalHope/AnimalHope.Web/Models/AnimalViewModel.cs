﻿namespace AnimalHope.Web.Models
{
    using AnimalHope.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class AnimalViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Animal Type")]
        public int AnimalTypeId { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public int ConditionId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [MinLength(3)]
        [MaxLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Picture")]
        public HttpPostedFileWrapper Picture { get; set; }

        public IEnumerable<AnimalType> AnimalTypes { get; set; }
        public IEnumerable<Condition> Conditions { get; set; }
    }
}