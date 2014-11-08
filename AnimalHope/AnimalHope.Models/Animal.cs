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

        public string Name { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }

        public virtual Type Type { get; set; }

        [ForeignKey("Condition")]
        public int ConditionId { get; set; }

        public virtual Condition Condition { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }

        public string Picture { get; set; }
    }
}
