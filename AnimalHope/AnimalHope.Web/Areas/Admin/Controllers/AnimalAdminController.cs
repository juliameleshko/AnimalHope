namespace AnimalHope.Web.Areas.Admin.Controllers
{
    using AnimalHope.Data;
    using AnimalHope.Models;
    using AnimalHope.Web.Areas.Admin.Models;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

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
            .To<AnimalAdminViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.data.Animals.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, AnimalAdminViewModel model)
        {
            var dbModel = base.Create<Animal>(model);
            if (dbModel != null) model.ID = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, AnimalAdminViewModel model)
        {
            var animal = this.data.Animals.All()
                .FirstOrDefault(a => a.Name == model.Name);
            
            var currentUser = animal!=null? animal.User: this.data.Users.GetById(this.User.Identity.GetUserId());

            model.User = currentUser;
            base.Update<Animal, AnimalAdminViewModel>(model, model.ID);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, AnimalAdminViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var animal = this.data.Animals.GetById(model.ID);
                var descIds = animal.Descriptions.Select(d => d.Id).ToList();

                foreach (var descId in descIds)
                {
                    this.data.Descriptions.Delete(descId);
                }

                this.data.SaveChanges();

                this.data.Animals.Delete(animal.Id);
                this.data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}