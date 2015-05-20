using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZooManagement.Startup))]
namespace ZooManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
