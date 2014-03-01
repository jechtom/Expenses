using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Expenses.Web.Startup))]
namespace Expenses.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
