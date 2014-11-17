namespace AnimalHope.Web.Controllers
{
    using AnimalHope.Data;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        protected IApplicationData data;

        protected BaseController(IApplicationData data)
        {
            this.data = data;
        }
    }
}