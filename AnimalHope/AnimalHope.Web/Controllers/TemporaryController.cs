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
    using AnimalHope.Models;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class TemporaryController : BaseController
    {
        public TemporaryController(IApplicationData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.data.Animals
                .All()
                .Where(a => a.Condition.Name == "At temporary home")
                .Project()
                .To<TemporaryViewModel>().ToList();

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
                return this.RedirectToAction("Index", "Temporary");
            }

            var viewModel = Mapper.Map<TemporaryDetailsViewModel>(model);

            viewModel.OrderedDescriptions = this.data.Descriptions.All().Where(d => d.AnimalId == id).OrderByDescending(d => d.CreatedOn);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adopt(TemporaryDetailsViewModel animal)
        {
            string errorMsg = "";

            if (ModelState.IsValid)
            {
                var model = this.GetAnimalData(animal.ID);

                if (model == null)
                {
                    return this.RedirectToAction("Index", "Temporary");
                }

                model.Condition = this.data.Conditions.All().Where(c => c.Name == "Adopted").FirstOrDefault();
                model.User = this.data.Users.GetById(User.Identity.GetUserId());

                model.Descriptions.Add(new Description
                {
                    Text = animal.Description,
                    User = this.data.Users.GetById(User.Identity.GetUserId()),
                    CreatedOn = DateTime.Now
                });

                this.data.SaveChanges();

                TempData["Success"] = "Animal was adopted successfuly.";
                return RedirectToAction("Index", "Adopted");
            }

            ViewData["Error"] = errorMsg;
            return View(animal);
        }
    }
}