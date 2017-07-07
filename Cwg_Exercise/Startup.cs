using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cwg_Exercise.Startup))]
namespace Cwg_Exercise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
