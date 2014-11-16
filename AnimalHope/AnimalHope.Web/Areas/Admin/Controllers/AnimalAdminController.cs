namespace AnimalHope.Web.Areas.Admin.Controllers
{
    using AnimalHope.Data;
    using AnimalHope.Web.Areas.Admin.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using AnimalHope.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class AnimalAdminController : AdminKendoGridController
    {
        public AnimalAdminController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.data.Animals.All()
            .Project()
            .To<AnimalViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.data.Animals.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, AnimalViewModel model)
        {
            var dbModel = base.Create<Animal>(model);
            if (dbModel != null) model.ID = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, AnimalViewModel model)
        {
            base.Update<Animal, AnimalViewModel>(model, model.ID);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, AnimalViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var animal = this.data.Animals.GetById(model.ID);

                foreach (var desc in animal.Descriptions)
                {
                    this.data.Descriptions.Delete(desc.Id);
                }

                this.data.SaveChanges();

                this.data.Locations.Delete(animal.LocationId);

                this.data.SaveChanges();

                foreach (var donation in animal.Vet.Donations)
                {
                    this.data.Donations.Delete(donation.Id);
                }

                this.data.SaveChanges();

                this.data.Vets.Delete(animal.VetId);

                this.data.SaveChanges();

                this.data.Animals.Delete(model.ID);
                this.data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}