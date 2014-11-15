namespace AnimalHope.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Donation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public decimal Amount { get; set; }

        [ForeignKey("Vet")]
        public int VetId { get; set; }

        public virtual Vet Vet { get; set; }
    }
}
