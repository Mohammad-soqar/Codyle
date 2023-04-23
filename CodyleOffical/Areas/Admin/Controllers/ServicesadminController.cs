using CodyleOffical.DataAccess;
using CodyleOffical.DataAccess.Repository;
using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using CodyleOffical.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace CodyleOffical.Areas.User.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class ServicesadminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;
        public ServicesadminController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _HostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Display(int? Id)
        {
            ServicesVM ServicesVM = new()
            {
                Services = new()
            };
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            else
            {
                ServicesVM.Services = _unitOfWork.Services.GetFirstOrDefault(u => u.Id == Id);
                return View(ServicesVM);
            }
           
        }
     
         

          

        #region API CALLS
        [HttpGet]
        public IActionResult GetAllServ()
        {
            var ServicesList = _unitOfWork.Services.GetAllServ();
            return Json(new { data = ServicesList });
        }

        [HttpDelete]

        public IActionResult DeletePost(int? Id)
        {
            var obj = _unitOfWork.Services.GetFirstOrDefault(u => u.Id == Id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }



            _unitOfWork.Services.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Event deleted successfuly" });
            return RedirectToAction("Index");

            return View(Id);

        }


        #endregion



    }
}
