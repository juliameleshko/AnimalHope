namespace AnimalHope.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AnimalType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
