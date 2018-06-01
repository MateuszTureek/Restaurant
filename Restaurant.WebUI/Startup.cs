using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Restaurant.Domain.Concrete;
using Restaurant.WebUI.App_Start;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Restaurant.WebUI.Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(Restaurant.WebUI.Startup))]

namespace Restaurant.WebUI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}
