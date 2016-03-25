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
    public class MietRoleManager : RoleManager<Role>
    {

        public MietRoleManager(RoleStore<Role> store) : base(store) { }



        public static MietRoleManager Create(IdentityFactoryOptions<MietRoleManager> options, IOwinContext context)
        {
            return new MietRoleManager(new RoleStore<Role>(context.Get<MainContext>()));
        }
    }
}