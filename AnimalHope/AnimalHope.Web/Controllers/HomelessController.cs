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
    using Microsoft.AspNet.Identity;
    using AnimalHope.Models;

    [Authorize]
    public class HomelessController : BaseController
    {
        public HomelessController(IApplicationData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.data.Animals
                .All()
                .Where(a => a.Condition.Name == "Homeless")
                .Project()
                .To<HomelessViewModel>().ToList();

            return View(model);
        }

        [HttpGet]
        private Animal GetAnimalData(int id)
        {
            if (id == -1)
            {
                return null;
            }

            var model = this.data.Animals.GetById(id);

            if (model == null)
            {
                return null;
            }

            return model;
        }

        [HttpGet]
        public ActionResult Details(int id = -1)
        {
            var model = this.GetAnimalData(id);

            if (model == null)
            {
                return this.RedirectToAction("Index", "Homeless");
            }

            var viewModel = Mapper.Map<HomelessDetailsViewModel>(model);

            viewModel.OrderedDescriptions = this.data.Descriptions.All().Where(d => d.AnimalId == id).OrderByDescending(d => d.CreatedOn);

            return View(viewModel);
        }
    }
}