﻿namespace AnimalHope.Web.Models
{
    using System;
    using AnimalHope.Models;
    using AnimalHope.Web.Infrastructure.Mapping;

    public class HomelessViewModel : IMapFrom<Animal>
    {
        private string picture;

        public int ID { get; set; }

        public string Name { get; set; }

        public AnimalType AnimalType { get; set; }

        public Condition Condition { get; set; }

        public Location Location { get; set; }

        public ApplicationUser User { get; set; }

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
    }
}