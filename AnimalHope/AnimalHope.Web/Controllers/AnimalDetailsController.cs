﻿namespace AnimalHope.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using AnimalHope.Data;
    using AnimalHope.Models;
    using AnimalHope.Web.Models;

    using AutoMapper;

    public class AnimalDetailsController : BaseController
    {
        public AnimalDetailsController(IApplicationData data)
            : base(data)
        {
        }

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

        public ActionResult Details(int id = -1)
        {
            var model = this.GetAnimalData(id);

            if (model == null)
            {
                return this.RedirectToAction("Index", "HomeController");
            }

            var viewModel = Mapper.Map<AnimalDetailsViewModel>(model);

            viewModel.OrderedDescriptions = this.data.Descriptions.All().Where(d => d.AnimalId == id).OrderByDescending(d => d.CreatedOn);

            return View(viewModel);
        }
    }
}