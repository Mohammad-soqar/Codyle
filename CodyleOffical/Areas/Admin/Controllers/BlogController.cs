using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models.ViewModels;
using CodyleOffical.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodyleOffical.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
     
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;

        public BlogController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _HostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

      


        public IActionResult Upsert(int? Id)
        {
            BlogVM BlogVM = new()
            {
                blog = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (Id == null || Id == 0)
            {
                return View(BlogVM);
            }
            else
            {
                BlogVM.blog = _unitOfWork.Blog.GetFirstOrDefault(u => u.Id == Id);
                return View(BlogVM);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BlogVM obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Blogs");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.blog.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.blog.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }


                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.blog.ImageUrl = @"\Images\Blogs\" + fileName + extension;
                }
                if (obj.blog.Id == 0)
                {
                    _unitOfWork.Blog.Add(obj.blog);
                }
                else
                {
                    _unitOfWork.Blog.Update(obj.blog);
                }


                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View();

        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var blogList = _unitOfWork.Blog.GetAll(includeProperties: "Category");
            return Json(new { data = blogList });
        }

        [HttpDelete]

        public IActionResult DeletePost(int? Id)
        {
            var obj = _unitOfWork.Blog.GetFirstOrDefault(u => u.Id == Id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_HostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Blog.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "blog deleted successfuly" });
            return RedirectToAction("Index");

            return View(Id);

        }


        #endregion


    }
}
