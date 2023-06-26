using Core.Generator;
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
    public class News : Controller
    {
        private IAdmin _admin;
        private IUser _User;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public News(IAdmin admin, IWebHostEnvironment webHostEnvironment, IUser User)
        {
            _User = User;
            _admin = admin;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: News
        public async Task<IActionResult> Index()
        {
            ViewBag.ViewTitle = "مدیریت اخبار";
            var result = await _admin.GetNews();
            return View(result);
        }
    
        [HttpPost]
        // Post // Uploadimage
        public async Task< ActionResult> Uploadimage(IFormFile files)
        {
            //Different situations
            if (ModelState.IsValid)
            {
                if (files == null)
                {
                    ViewBag.message = "کاربر گرامی لطفا قبل از ثبت خبر جدید یک تصویر برای خبر انتخاب نمایید";
                    return View();
                }
                var  supportedTypes = new[] { "jpg", "jpeg", "png", "bmp" };
                var fileExt = System.IO.Path.GetExtension(files.FileName).Substring(1);
                if(!supportedTypes.Contains(fileExt))
                {
                    ViewBag.message = "شما مجاز به وارد کردن فایل با فرمت های jpg-jpeg-gif-png-bmp می باشد";
                    return View();
                }
                if(files.Length>0)
                {
                    //Create Guid Name=> "-Guid+NameFile"
                    string createfilename = Guid.NewGuid().ToString().Replace("-", "");
                    var fileName = createfilename + Path.GetFileName(files.FileName);
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    //Upload In Location + Trim EndtoStart
                    var path = webRootPath + "\\upload\\indexImage\\normalimage\\" + fileName.Trim();

                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        await files.CopyToAsync(fileStream);
                    }

                    return Json(new { status = "success", message = "تصویر با موفقیت آپلود شد.", imagename = fileName }); 
                }

            }
            return View();
        }

        // GET: News/Create
        public async Task<ActionResult> Create()
        {
            PlaceNewsInIndexPageViewModel indexPage = new PlaceNewsInIndexPageViewModel();

           
            ViewBag.CategoryID_fk = new SelectList(await _admin.GetCategories(), "id", "Title");
            ViewBag.PlaceNewsID= new SelectList(indexPage.GetPlaceNewsInIndexPageViewModel(), "id", "Title");
            ViewBag.UserID = new SelectList(await _User.GetUsers(), "FullName");
            ViewBag.Shamsidate = DateTimeGenrators.GetShamsiDate();
            ViewBag.NowTime = DateTimeGenrators.GetShamsiTime();

            return View();
        }

        // POST: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(NewsViewModelForInsert model )
        {
            PlaceNewsInIndexPageViewModel indexPage = new PlaceNewsInIndexPageViewModel();
           if(ModelState.IsValid)
            {
                _admin.AddNews(model);
                return Redirect("Index");
            }
            ViewBag.CategoryID_fk = new SelectList(await _admin.GetCategories(), "id", "Title");
            ViewBag.PlaceNewsID = new SelectList(indexPage.GetPlaceNewsInIndexPageViewModel(), "id", "Title");
            return View(model);
        }

        // GET: News/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            var result = await _admin.GetNewsByID(id);
            NewsViewModel News = new NewsViewModel
            {
                Abstract=result.Abstract,
                Title=result.Title,
                CategoryID_fk = result.CategoryID_fk,
                IndexImage = result.IndexImage,
                Content = result.Content,
                UserID_fk = result.UserID_fk,
                PlaceNewsID = result.PlaceNewsID,
                NewsType = result.NewsType
            };
            ViewBag.CategoryID_fk = new SelectList(await _admin.GetCategories(), "id", "Title", result.CategoryID_fk);
            ViewBag.UserID_fk = new SelectList(await _User.GetUsers(), "Id", "Title", result.UserID_fk);

            PlaceNewsInIndexPageViewModel indexPage = new PlaceNewsInIndexPageViewModel();
            ViewBag.PlaceNewsID = new SelectList(indexPage.GetPlaceNewsInIndexPageViewModel(),"id","Title",result.PlaceNewsID);
            return View(News);
        }

        // POST: News/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NewsViewModel model, string newIndexImage, string currentImageName)
        {
           if(ModelState.IsValid)
           {
               try
               {
                    if (newIndexImage != null)
                    {
                        model.IndexImage = newIndexImage;
                    }
                    else
                    {

                        model.IndexImage = currentImageName;
                    }

                    bool result = _admin.UpdateNews(id, model);
                    if (result)
                        ViewBag.SuccessMessage = "اطلاعات با موفقیت ثبت شد";
                    return RedirectToAction(nameof(Index));
               }
                catch
                {
                    throw;
                }
              
           }
            else
            {
                return View(model);
            }
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: News/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}