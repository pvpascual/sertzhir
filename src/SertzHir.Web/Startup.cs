using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchzHir.Web.Startup))]
namespace SearchzHir.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
