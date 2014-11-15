namespace AnimalHope.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Animal
    {
        public Animal()
        {
            this.Descriptions = new HashSet<Description>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("AnimalType")]
        public int AnimalTypeId { get; set; }

        public virtual AnimalType AnimalType { get; set; }

        [Required]
        [ForeignKey("Condition")]
        public int ConditionId { get; set; }

        public virtual Condition Condition { get; set; }

        [ForeignKey("Vet")]
        public int VetId { get; set; }

        public virtual Vet Vet { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }

        public byte[] Picture { get; set; }

        public string PictureType { get; set; }
    }
}
