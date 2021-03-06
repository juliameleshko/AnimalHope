﻿namespace AnimalHope.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AnimalHope.Data;
    using AnimalHope.Models;
    using AnimalHope.Web.Models;
    using AnimalHope.Web.Utilities;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class AnimalController : BaseController
    {
        public AnimalController(IApplicationData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            var allTypes = this.data.AnimalTypes.All().ToList();
            var allConditions = this.data.Conditions.All().ToList();

            var model = new AnimalViewModel()
            {
                AnimalTypes = allTypes,
                Conditions = allConditions
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalViewModel animal)
        {
            string errorMsg = "";
            var existingAnimal = this.data.Animals.All().FirstOrDefault(a => a.Name == animal.Name);
            if (existingAnimal != null)
            {
                if (existingAnimal.Name == animal.Name)
                {
                    errorMsg = "Animal with this name already exist!";
                    ModelState.AddModelError("Animal name", "Animal with this name already exist!");
                }
            }

            if (ModelState.IsValid)
            {
                var animalModel = new Animal
                {
                    Name = animal.Name,
                    AnimalTypeId = animal.AnimalTypeId,
                    ConditionId = animal.ConditionId,
                    User = this.data.Users.GetById(User.Identity.GetUserId())
                };

                if (animal.Picture != null)
                {
                    animalModel.Picture = HttpPostedFileWrapperExtensions.GetResizedImage(animal.Picture);
                    animalModel.PictureType = animal.Picture.ContentType;
                }
                else
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Content\\Images\\paw.png";
                    animalModel.Picture = System.IO.File.ReadAllBytes(path);
                    animalModel.PictureType = "images/png";
                }

                if (animal.Location.Latitude == null)
                {
                    animal.Location.Latitude = "0";
                }

                if (animal.Location.Longitude == null)
                {
                    animal.Location.Longitude = "0";
                }

                if (animal.Vet.Cost == null)
                {
                    animal.Vet.Cost = 0;
                }

                animalModel.Descriptions.Add(new Description
                {
                    Text = animal.Description,
                    User = this.data.Users.GetById(User.Identity.GetUserId()),
                    CreatedOn = DateTime.Now
                });

                animalModel.Location = new Location
                {
                    Latitude = animal.Location.Latitude,
                    Longitude = animal.Location.Longitude
                };

                animalModel.Vet = new Vet
                {
                    Cost = animal.Vet.Cost
                };

                this.data.Animals.Add(animalModel);
                this.data.SaveChanges();

                TempData["Success"] = "Animal was created successfuly.";
                return RedirectToAction("Index", "Home");
            }

            animal.AnimalTypes = this.data.AnimalTypes.All().ToList();
            animal.Conditions = this.data.Conditions.All().ToList();

            ViewData["Error"] = errorMsg;
            return View(animal);
        }
    }
}