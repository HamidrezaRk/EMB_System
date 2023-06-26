using Core.Generator;
using emb_project.Entity;
using emb_project.Interface;
using emb_project.Viewmodel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace emb_project.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserManagement : Controller
    {
        
        //ctor
        private IUser _user;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserManagement(IUser user, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
           _user  = user;
        }
        // GET: UserManagement
        public async Task <IActionResult> Index()
        {
            var result = await _user.GetUsers();
            return View(result);
        }

        // GET: UserManagement/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Shamsidate = DateTimeGenrators.GetShamsiDate();

            ViewBag.Roleid_fk = new SelectList(await _user.GetRoles(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Uploadimage(IFormFile files)
        {
            //Different situations
            if (ModelState.IsValid)
            {
                if (files == null)
                {
                    ViewBag.message = "کاربر گرامی لطفا قبل از ثبت خبر جدید یک تصویر برای خبر انتخاب نمایید";
                    return View();
                }
                var supportedTypes = new[] { "jpg", "jpeg", "png", "bmp" };
                var fileExt = System.IO.Path.GetExtension(files.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    ViewBag.message = "شما مجاز به وارد کردن فایل با فرمت های jpg-jpeg-gif-png-bmp می باشد";
                    return View();
                }
                if (files.Length > 0)
                {
                    //Create Guid Name=> "-Guid+NameFile"
                    string createfilename = Guid.NewGuid().ToString().Replace("-", "");
                    var fileName = createfilename + Path.GetFileName(files.FileName);
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    //Upload In Location + Trim EndtoStart
                    var path = webRootPath + "\\upload\\indexImage\\userimage\\normalimage\\" + fileName.Trim();

                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        await files.CopyToAsync(fileStream);
                    }

                    return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagename = fileName });
                }

            }
            return View();
        }
        // POST: UserManagement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User model, string imagename)
        {
            if(ModelState.IsValid)
            {
                if(imagename ==null)
                {
                    model.UserAvatar= "defaultpic.jpg";
                }
                else
                {
                    model.UserAvatar = imagename;
                }
                _user.AddUser(model);
                ViewBag.SuccessMessage = "اطلاعات با موفقیت ثبت شد";
            }
            ViewBag.RoleId_Fk = new SelectList(await _user.GetRoles(), "Id", "Title", model.RoleId_Fk);
            return View(model);
        }

        // GET: UserManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserManagement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit(int id, UserViewModel model,string imagename, string chkinput)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.GetUserByID(id);
                if (imagename != null)
                {
                    model.UserAvatar = imagename;
                }
                else
                {
                    model.UserAvatar = user.UserAvatar;
                }

                if (chkinput == "on")
                {

                    //Reset Password
                    //123d@F
                    model.Password = "123d@F";
                }
                else
                {

                    model.Password = user.Password;
                }
                bool result = _user.UpdateUser(id, model);
                if (result)
                {
                    //return RedirectToAction(nameof(Index));
                    ViewBag.SuccessMessage = "اطلاعات با موفقیت ویرایش شد";
                }
            }
            ViewBag.RoleId_Fk = new SelectList(await _user.GetRoles(), "Id", "Title", model.RoleId_Fk);
            return View(model);
        }

        // GET: UserManagement/Delete/5
        public async Task< IActionResult> Delete(int id)
        {
            var Result =  await _user.GetUserByID(id);
            ViewBag.Name = Result.FullName;
            ViewBag.user_id = id;
            //if(Result==null)
            //{
            //    return NotFound();
            //}
            return View("Delete") ;
        }

        // POST: UserManagement/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken,ActionName("Delete")]
        public IActionResult DeleteUser(int id)
        {
            _user.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
