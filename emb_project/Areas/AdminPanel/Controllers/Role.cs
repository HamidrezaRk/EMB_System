using emb_project.Interface;
using emb_project.Viewmodel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb_project.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class Role : Controller
    {
        private IUser _Role;
        public Role(IUser Role)
        {
            _Role = Role;
        }

        // GET: Role
        public async Task< ActionResult> Index()
        {
            var  Result = await _Role.GetRoles();
            return View(Result);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _Role.AddRoll(model);
                ViewBag.SuccessMessage = "اطلاعات با موفقیت ثبت شد";

            }
            return View(model);
        }

        // GET: Role/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            var Result = await _Role.GetRoleByID(id);

            RoleViewModel role = new RoleViewModel
            {
                Name = Result.Name,
                Title = Result.Title
            };
            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RoleViewModel model)
        {
           if(ModelState.IsValid)
           {
                bool result = _Role.UpdateRoll(id, model);
                if(result)
                    ViewBag.SuccessMessage = "اطلاعات با موفقیت تغییر کرد.";
 
           }

            return View(model);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _Role.GetRoleByID(id);
            ViewBag.Role_Name = result.Result.Name;
            ViewBag.Role_ID = id;
            if(result==null)
            {
                return NotFound();
            }
            return PartialView();
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            _Role.DeleteRole(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
