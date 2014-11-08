namespace AnimalHope.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vet
    {
        public Vet()
        {
            this.Donations = new HashSet<Donation>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }

        public decimal Cost { get; set; }

        public ICollection<Donation> Donations { get; set; }
    }
}
