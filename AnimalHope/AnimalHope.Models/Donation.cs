namespace AnimalHope.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Donation
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal Amount { get; set; }
    }
}
