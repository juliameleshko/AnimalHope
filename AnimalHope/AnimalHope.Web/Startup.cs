using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimalHope.Web.Startup))]

namespace AnimalHope.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
