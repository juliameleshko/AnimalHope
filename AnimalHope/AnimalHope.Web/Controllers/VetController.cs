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
    public class VetController : BaseController
    {
        public VetController(IApplicationData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.data.Animals
                .All()
                .Where(a => a.Condition.Name == "At vet's office")
                .Project()
                .To<VetViewModel>().ToList();

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
                return this.RedirectToAction("Index", "Vet");
            }

            var viewModel = Mapper.Map<VetDetailsViewModel>(model);

            viewModel.OrderedDescriptions = this.data.Descriptions.All().Where(d => d.AnimalId == id).OrderByDescending(d => d.CreatedOn);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adopt(VetDetailsViewModel animal)
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
        public ActionResult AddToTemporary(VetDetailsViewModel animal)
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
        public ActionResult Donate(VetDetailsViewModel animal)
        {
            string errorMsg = "";

            if (!animal.DonationAmount.HasValue)
            {
                this.ModelState.AddModelError("DonationAmount", "The Field \"Donation Amount\" is required.");
                errorMsg = "Donation Amount is required.";
            }

            if (ModelState.IsValid)
            {
                var model = this.GetAnimalData(animal.ID);

                if (model == null)
                {
                    return this.RedirectToAction("Index", "Vet");
                }

                model.Vet.Donations.Add(new Donation
                    {
                        Amount = animal.DonationAmount.Value,
                        User = this.data.Users.GetById(User.Identity.GetUserId())
                    });

                model.Descriptions.Add(new Description
                {
                    Text = "Donated " + animal.DonationAmount + " by " + this.data.Users.GetById(User.Identity.GetUserId()).Email + ".",
                    User = this.data.Users.GetById(User.Identity.GetUserId()),
                    CreatedOn = DateTime.Now
                });

                this.data.SaveChanges();

                TempData["Success"] = "Donation was made successfuly.";

                return this.RedirectToAction("Details", new { id = animal.ID });
            }

            TempData["Error"] = errorMsg;
            return this.RedirectToAction("Details", new { id = animal.ID });
        }
    }
}