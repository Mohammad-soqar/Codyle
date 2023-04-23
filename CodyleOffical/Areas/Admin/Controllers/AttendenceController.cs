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

    public class AttendenceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;

        public AttendenceController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            AttendenceVM AttendenceVM = new()
            {
                Attendence = new(),
               
                EventList = _unitOfWork.Event.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Title,
                    Value = i.Id.ToString()
                })
            };
            if (Id == null || Id == 0)
            {
                return View(AttendenceVM);
            }
            else
            {
                AttendenceVM.Attendence = _unitOfWork.Attendences.GetFirstOrDefault(u => u.Id == Id);
                return View(AttendenceVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(AttendenceVM obj)
        {
            if (ModelState.IsValid)
            {
                
                if (obj.Attendence.Id == 0)
                {
                    _unitOfWork.Attendences.Add(obj.Attendence);
                }
                else
                {
                    _unitOfWork.Attendences.Update(obj.Attendence);
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

            var categoryFromDb = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == Id);

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
            var AttendencesList = _unitOfWork.Attendences.GetAll(includeProperties:"Event");
            return Json(new { data = AttendencesList });
        }

        [HttpDelete]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _unitOfWork.Attendences.GetFirstOrDefault(u => u.Id == Id);

            if (obj == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }
          

            _unitOfWork.Attendences.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Event deleted successfuly" });
            return RedirectToAction("Index");

            return View(Id);

        }


        #endregion


    }


}
