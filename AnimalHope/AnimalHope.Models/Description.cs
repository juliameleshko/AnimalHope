
namespace AnimalHope.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Description
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}
