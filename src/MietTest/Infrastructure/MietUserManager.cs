using DbLayer.Contexts;
using DbLayer.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MietTest.Infrastructure
{
    public class MietUserManager: UserManager<User>
    {
        public MietUserManager(IUserStore<User> store) : base(store) { }


        public static MietUserManager Create(IdentityFactoryOptions<MietUserManager> options, IOwinContext context)
        {
            MainContext db = context.Get<MainContext>();
            MietUserManager manager = new MietUserManager(new UserStore<User>(db));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false, //true,
                RequireUppercase = false//true
            };
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            return manager;
        }
    }
}