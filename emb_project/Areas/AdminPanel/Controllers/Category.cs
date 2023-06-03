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
    public class Category : Controller
    {
        //ctor
        private IAdmin _admin;
        public Category(IAdmin admin)
        {
            _admin = admin;
        }
            
        // GET: Category
        public async Task<ActionResult> Index()
        {
            var result = await _admin.GetCategories();
            return View(result);
        }



        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                _admin.AddCategory(model);
                ViewBag.SuccessMessage = "اطلاعات با موفقیت ثبت شد";
            }
            return View(model);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult>Edit(int id)
        {
            var result=await _admin.GetCategoriesByid(id);
            CategoryViewModel category = new CategoryViewModel
            {
                Title = result.Title,
                Description=result.Description
            };
            ViewBag.id = id;

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,CategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                bool result = _admin.UpdateCategory(id, model);
                if(result!=false)
                {
                    ViewBag.SuccessMessage = "اطلاعات با موفقیت ویرایش شد";
                }
            }
            return View(model);
        }

        // GET: Category/Delete/5
        public  ActionResult Delete(int id)
        {
            var result = _admin.GetCategoriesByid(id);
            ViewBag.Cat_Name = result.Result.Title;
            ViewBag.Cat_id = id;
            if (result != null)
            {
                return NotFound();
            }
            return PartialView();
            
        }

        // POST: Category/Delete/5
        [HttpPost ,ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            _admin.DeleteCategory(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
