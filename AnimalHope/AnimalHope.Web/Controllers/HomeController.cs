namespace AnimalHope.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AnimalHope.Data;
    using AnimalHope.Web.Models;
    using AutoMapper.QueryableExtensions;

    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.data.Animals.All()
                        .Project()
                        .To<AllAnimalsViewModel>().ToList();
            return View(model);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}