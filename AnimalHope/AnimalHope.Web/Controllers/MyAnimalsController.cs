namespace AnimalHope.Web.Controllers
{
    using AnimalHope.Data;
    using AnimalHope.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;

    public class MyAnimalsController : BaseController
    {
        public MyAnimalsController(IApplicationData data)
            : base(data)
        {
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult MyAnimals()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var model = this.data.Animals
                .All()
                .Where(a => a.User.Id == currentUserId)
                .Project()
                .To<MyAnimalsViewModel>().ToList();

            return PartialView("_MyAnimals", model);
        }
    }
}