using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestTry2.Startup))]
namespace TestTry2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
