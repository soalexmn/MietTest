using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MietTest.Models;
using Owin;
using DbLayer.Contexts;
using Microsoft.Owin.Security.Cookies;
using MietTest.Infrastructure;

namespace MietTest
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {


            // Метод CreatePerOwinContext регистрирует в OWIN менеджер пользователей AppUserManager и класс контекста AppIdentityDbContext
            app.CreatePerOwinContext<MainContext>(MainContext.Create);
            app.CreatePerOwinContext<MietUserManager>(MietUserManager.Create);
            app.CreatePerOwinContext<MietRoleManager>(MietRoleManager.Create);

            //Метод UseCookieAuthentication с помощью объекта CookieAuthenticationOptions
            //устанавливает аутентификацию на основе куки в качестве типа аутентификации в приложении.
            //А свойство LoginPath позволяет установить адрес URL, по которому будут перенаправляться неавторизованные пользователи. Как правило, это адрес /Account/Login.

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}
