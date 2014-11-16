namespace AnimalHope.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using AnimalHope.Data;
    using AnimalHope.Web.Controllers;
    using AnimalHope.Web.Areas.Admin.Models;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : Controller
    {
        protected IApplicationData data;

        protected AdminController(IApplicationData data)
        {
            this.data = data;
        }
    }
}