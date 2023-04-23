using CodyleOffical.DataAccess;
using CodyleOffical.DataAccess.Repository;
using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using CodyleOffical.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace CodyleOffical.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            CompanyVM Company = new()
            {
                Company = new(),
                ApplicationCompanyList = _unitOfWork.CompType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (Id == null || Id == 0)
            {
                return View(Company);
            }
            else
            {
                Company.Company = _unitOfWork.ApplicationCompany.GetFirstOrDefault(u => u.Id == Id);
                return View(Company);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CompanyVM obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\CompanyLogo");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Company.ImageUrl !=null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath,obj.Company.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }


                    }
                    using(var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Company.ImageUrl = @"\Images\CompanyLogo\" + fileName + extension;
                }
                if (obj.Company.Id == 0)
                {
                    _unitOfWork.ApplicationCompany.Add(obj.Company);
                }
                else
                {
                    _unitOfWork.ApplicationCompany.Update(obj.Company);
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

            var categoryFromDb = _unitOfWork.CompType.GetFirstOrDefault(u => u.Id == Id);

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
            var ApplicationCompanyList = _unitOfWork.ApplicationCompany.GetAll(includeProperties: "CompType");
            return Json(new { data = ApplicationCompanyList });
        }

        [HttpDelete]
      
        public IActionResult DeletePost(int? Id)
        {
            var obj = _unitOfWork.ApplicationCompany.GetFirstOrDefault(u => u.Id == Id);

            if (obj == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }

            var oldImagePath = Path.Combine(_HostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.ApplicationCompany.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Company deleted successfuly" });
            return RedirectToAction("Index");

            return View(Id);

        }


        #endregion


    }


}
