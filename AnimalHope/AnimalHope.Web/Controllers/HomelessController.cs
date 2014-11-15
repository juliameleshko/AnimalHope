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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adopt(HomelessDetailsViewModel animal)
        {
            string errorMsg = "";

            if (string.IsNullOrEmpty(animal.Description))
            {
                ModelState.AddModelError("Description", "Description is required.");
                errorMsg = "Description is required.";
            }

            if (ModelState.IsValid)
            {
                var model = this.GetAnimalData(animal.ID);

                if (model == null)
                {
                    return this.RedirectToAction("Index", "Vet");
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

            TempData["Error"] = errorMsg;
            return this.RedirectToAction("Details", new { id = animal.ID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToTemporary(HomelessDetailsViewModel animal)
        {
            string errorMsg = "";

            if (string.IsNullOrEmpty(animal.Description))
            {
                ModelState.AddModelError("Description", "Description is required.");
                errorMsg = "Description is required.";
            }

            if (ModelState.IsValid)
            {
                var model = this.GetAnimalData(animal.ID);

                if (model == null)
                {
                    return this.RedirectToAction("Index", "Vet");
                }

                model.Condition = this.data.Conditions.All().Where(c => c.Name == "At temporary home").FirstOrDefault();
                model.User = this.data.Users.GetById(User.Identity.GetUserId());

                model.Descriptions.Add(new Description
                {
                    Text = animal.Description,
                    User = this.data.Users.GetById(User.Identity.GetUserId()),
                    CreatedOn = DateTime.Now
                });

                this.data.SaveChanges();

                TempData["Success"] = "Animal was moved to temporary home successfuly.";
                return RedirectToAction("Index", "Temporary");
            }

            TempData["Error"] = errorMsg;
            return this.RedirectToAction("Details", new { id = animal.ID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToVet(HomelessDetailsViewModel animal)
        {
            string errorMsg = "";

            if (string.IsNullOrEmpty(animal.Description))
            {
                ModelState.AddModelError("Description", "Description is required.");
                errorMsg = "Description is required.";
            }

            if (!animal.CostAmount.HasValue)
            {
                this.ModelState.AddModelError("CostAmount", "The Field \"Cost Amount\" is required.");
                errorMsg = "Cost Amount is required.";
            }

            if (ModelState.IsValid)
            {
                var model = this.GetAnimalData(animal.ID);

                if (model == null)
                {
                    return this.RedirectToAction("Index", "Vet");
                }

                model.Condition = this.data.Conditions.All().Where(c => c.Name == "At vet's office").FirstOrDefault();
                model.User = this.data.Users.GetById(User.Identity.GetUserId());

                model.Descriptions.Add(new Description
                {
                    Text = animal.Description,
                    User = this.data.Users.GetById(User.Identity.GetUserId()),
                    CreatedOn = DateTime.Now
                });

                model.Vet.Cost = animal.CostAmount;

                this.data.SaveChanges();

                TempData["Success"] = "Animal was moved to vet's office successfuly.";
                return RedirectToAction("Index", "Vet");
            }

            TempData["Error"] = errorMsg;
            return this.RedirectToAction("Details", new { id = animal.ID });
        }
    }
}