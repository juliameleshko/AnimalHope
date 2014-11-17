namespace AnimalHope.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using AnimalHope.Data;

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