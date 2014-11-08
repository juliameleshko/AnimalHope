namespace AnimalHope.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Condition
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
