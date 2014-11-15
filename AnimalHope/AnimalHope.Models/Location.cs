namespace AnimalHope.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Location
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue("0")]
        public string Latitude { get; set; }

        [DefaultValue("0")]
        public string Longitude { get; set; }
    }
}
