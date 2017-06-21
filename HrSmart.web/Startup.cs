using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HrSmart.web.Startup))]
namespace HrSmart.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
