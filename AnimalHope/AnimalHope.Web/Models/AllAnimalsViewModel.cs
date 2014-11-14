namespace AnimalHope.Web.Models
{
    using System;
    using System.Collections.Generic;

    using AnimalHope.Models;
    using AnimalHope.Web.Infrastructure.Mapping;

    using AutoMapper;

    public class AllAnimalsViewModel : IHaveCustomMappings
    {
        private string picture;

        public int ID { get; set; }

        public string Name { get; set; }

        public AnimalType AnimalType { get; set; }

        public Condition Condition { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<Description> Descriptions { get; set; }

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

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Animal, AllAnimalsViewModel>();
            //.ForMember(x => x.PictureType, opt => opt.MapFrom(m => m.PictureType))
            //.ForMember(x => x.Picture, opt => opt.MapFrom(m => m.Picture));
        }

        private string GetBase64(string imageType, byte[] imageData)
        {
            var binaryContent = Convert.ToBase64String(imageData);
            var imageBase64 = string.Format("data:{0};base64,{1}", imageType, binaryContent);
            return imageBase64;
        }
    }
}