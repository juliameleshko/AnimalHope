namespace AnimalHope.Web.Models
{
    using AnimalHope.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class AnimalViewModel
    {
        public AnimalViewModel()
        {
            this.AnimalTypes = new HashSet<AnimalType>();
            this.Conditions = new HashSet<Condition>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Animal Type")]
        public int AnimalTypeId { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public int ConditionId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Picture")]
        public HttpPostedFileWrapper Picture { get; set; }

        public IEnumerable<AnimalType> AnimalTypes { get; set; }
        public IEnumerable<Condition> Conditions { get; set; }
    }
}