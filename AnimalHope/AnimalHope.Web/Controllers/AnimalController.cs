namespace AnimalHope.Web.Controllers
{
    using AnimalHope.Data;
    using AnimalHope.Web.Models;
    using System.Web.Mvc;
    using System.Linq;
    using AnimalHope.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using AnimalHope.Web.Utilities;

    public class AnimalController : BaseController
    {
        public AnimalController(IApplicationData data)
            : base(data)
        {
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}

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

                this.data.Animals.Add(animalModel);

                this.data.SaveChanges();

                //if (animal.Picture != null)
                //{
                //    animalModel.Picture = HttpPostedFileWrapperExtensions.GetResizedImage(animal.Picture);
                //    animalModel.PictureType = animal.Picture.ContentType;
                //}

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