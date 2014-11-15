namespace AnimalHope.Web.Models
{
    using AnimalHope.Models;
    using AnimalHope.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class HomelessDetailsViewModel : IMapFrom<Animal>, IHaveCustomMappings
    {
        private string picture;

        public int ID { get; set; }

        public string Name { get; set; }

        public AnimalType AnimalType { get; set; }

        public Condition Condition { get; set; }

        public ApplicationUser User { get; set; }

        [MinLength(3)]
        [MaxLength(500)]
        public string Description { get; set; }

        public IEnumerable<Description> Descriptions { get; set; }

        public IEnumerable<Description> OrderedDescriptions { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public decimal? CostAmount { get; set; }

        public string PictureType { get; set; }

        public byte[] Picture { get; set; }

        public string PictureData
        {
            get
            {
                if (this.picture == null && this.PictureType != null && this.Picture != null)
                {
                    this.picture = GetBase64(this.PictureType, this.Picture);
                }

                return this.picture;
            }
        }

        private string GetBase64(string imageType, byte[] imageData)
        {
            var binaryContent = Convert.ToBase64String(imageData);
            var imageBase64 = string.Format("data:{0};base64,{1}", imageType, binaryContent);
            return imageBase64;
        }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Location, HomelessDetailsViewModel>()
                .ForMember(x => x.Latitude, opt => opt.MapFrom(m => m.Latitude))
                .ForMember(x => x.Longitude, opt => opt.MapFrom(m => m.Longitude));
        }
    }
}