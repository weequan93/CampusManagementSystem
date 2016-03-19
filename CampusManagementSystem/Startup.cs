using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampusManagementSystem.Startup))]
namespace CampusManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
