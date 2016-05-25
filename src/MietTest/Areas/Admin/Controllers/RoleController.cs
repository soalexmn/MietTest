using DbLayer.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MietTest.Areas.Admin.Models;
using MietTest.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MietTest.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        public ActionResult Index()
        {
            var roles = RoleManager.Roles.ToArray();
            return View(roles);
        }
        //------------------------------------------------------------------
        public ActionResult Create()
        {
            return View();
        }
        //-------------------------------------------------------------------
        [HttpPost]
        public async Task<ActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await RoleManager.CreateAsync(new Role(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }
        //---------------------------------------------------------------------
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            Role role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Роль не найдена" });
            }
        }
        //---------------------------------------------------------------------
        public async Task<ActionResult> Edit(string id)
        {
            Role role = await RoleManager.FindByIdAsync(id);
            string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();
            var members = UserManager.Users.Where(x => memberIDs.Any(y => y == x.Id));
            var nonMembers = UserManager.Users.Except(members);
            return View(new RoleEditModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }
        //----------------------------------------------------------------------
        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    result = await UserManager.AddToRoleAsync(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    result = await UserManager.RemoveFromRoleAsync(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "Роль не найдена" });
        }
        //----------------------------------------------------------------------
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        //---------------------------------------------------------------------
        private MietUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<MietUserManager>();
            }
        }
        //-------------------------------------------------------------------------
        private MietRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<MietRoleManager>();
            }
        }
        //--------------------------------------------------------------------------
    }
}