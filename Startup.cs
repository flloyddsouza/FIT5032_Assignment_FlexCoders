using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlexCoders_Assignment.Startup))]
namespace FlexCoders_Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
