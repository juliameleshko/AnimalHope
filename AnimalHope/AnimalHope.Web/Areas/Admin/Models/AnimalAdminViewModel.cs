using AnimalHope.Models;
using AnimalHope.Web.Infrastructure.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalHope.Web.Areas.Admin.Models
{
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