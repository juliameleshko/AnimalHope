namespace AnimalHope.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    using AnimalHope.Models;
    using AnimalHope.Web.Infrastructure.Mapping;

    public class AnimalAdminViewModel : IMapFrom<Animal>
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int AnimalTypeID { get; set; }

        public int ConditionId { get; set; }

        public ApplicationUser User { get; set; }
    }
}