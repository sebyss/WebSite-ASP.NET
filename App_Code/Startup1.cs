using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Startup1))]

public class Startup1
{
    public void Configuration(IAppBuilder app)
    {
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Pages/Account/Login.aspx")
        });
    }
}
