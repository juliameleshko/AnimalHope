namespace AnimalHope.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AnimalHope.Data;
    using AnimalHope.Web.Models;
    using AutoMapper.QueryableExtensions;

    [Authorize]
    public class AdoptedController : BaseController
    {
        public AdoptedController(IApplicationData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.data.Animals
                .All()
                .Where(a => a.Condition.Name == "Adopted")
                .Project()
                .To<AdoptedViewModel>().ToList();

            return View(model);
        }
    }
}