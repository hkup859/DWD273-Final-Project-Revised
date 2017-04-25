using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DWD273_Final_Project_Revised.Startup))]
namespace DWD273_Final_Project_Revised
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
