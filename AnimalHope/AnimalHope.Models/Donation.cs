namespace AnimalHope.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Donation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
