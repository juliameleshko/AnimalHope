namespace AnimalHope.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
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

        [DefaultValue(0)]
        public decimal? Cost { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
