namespace AnimalHope.Web.Controllers
{
    using AnimalHope.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using AnimalHope.Web.Models;

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
    }
}