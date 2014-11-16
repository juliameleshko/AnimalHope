namespace AnimalHope.Web.Controllers
{
    using AnimalHope.Data;
    using AnimalHope.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class StatisticsController : BaseController
    {
        public StatisticsController(IApplicationData data)
            : base(data)
        {
        }

        [HttpGet]
        [ChildActionOnly]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult Stats()
        {
            var model = new StatisticsViewModel
            {
                HomelessCount = this.data.Animals.All().Where(a => a.Condition.Name == "Homeless").Count(),
                VetCount = this.data.Animals.All().Where(a => a.Condition.Name == "At vet's office").Count(),
                TempCount = this.data.Animals.All().Where(a => a.Condition.Name == "At temporary home").Count(),
                AdoptedCount = this.data.Animals.All().Where(a => a.Condition.Name == "Adopted").Count()
            };

            return PartialView("_Stats", model);
        }
    }
}