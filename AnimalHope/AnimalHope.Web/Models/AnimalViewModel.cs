namespace AnimalHope.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using AnimalHope.Models;
    using AnimalHope.Web.Infrastructure.Mapping;
    using System.Web.Mvc;

    public class AnimalViewModel : IMapFrom<Animal>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Animal Type")]
        public int AnimalTypeId { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public int ConditionId { get; set; }

        public ApplicationUser User { get; set; }

        public Location Location { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Description { get; set; }

        public Vet Vet { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Picture")]
        public HttpPostedFileWrapper Picture { get; set; }

        public IEnumerable<AnimalType> AnimalTypes { get; set; }

        public IEnumerable<Condition> Conditions { get; set; }
    }
}