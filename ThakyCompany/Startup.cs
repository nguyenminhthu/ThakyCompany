using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThakyCompany.Startup))]
namespace ThakyCompany
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
