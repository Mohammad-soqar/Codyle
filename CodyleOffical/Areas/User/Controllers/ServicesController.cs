using CodyleOffical.DataAccess;
using CodyleOffical.DataAccess.Repository;
using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using CodyleOffical.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Security.Claims;

namespace CodyleOffical.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]

    public class ServicesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;

        public ServicesController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _HostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }



        public IActionResult Upsert(int? Id)
        {
            
            ServicesVM ServicesVM = new()
            {
                Services = new(),
                
            };

            if (Id == null || Id == 0)
            {
                return View(ServicesVM);
            }
            else
            {
                ServicesVM.Services = _unitOfWork.Services.GetFirstOrDefault(u => u.Id == Id);
                return View(ServicesVM);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ServicesVM obj)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;

                if (obj.Services.Id == 0)
                {
                    _unitOfWork.Services.Add(obj.Services);
                }
                else
                {
                    _unitOfWork.Services.Update(obj.Services);
                }


                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        //branding
        public IActionResult UpsertB(int? Id)
        {

            ServicesVM ServicesVM = new()
            {
                Services = new(),

            };

            if (Id == null || Id == 0)
            {
                return View(ServicesVM);
            }
            else
            {
                ServicesVM.Services = _unitOfWork.Services.GetFirstOrDefault(u => u.Id == Id);
                return View(ServicesVM);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertB(ServicesVM obj)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;

                if (obj.Services.Id == 0)
                {
                    _unitOfWork.Services.Add(obj.Services);
                }
                else
                {
                    _unitOfWork.Services.Update(obj.Services);
                }


                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(obj);

        }
        //Social Media
        public IActionResult UpsertS(int? Id)
        {

            ServicesVM ServicesVM = new()
            {
                Services = new(),

            };

            if (Id == null || Id == 0)
            {
                return View(ServicesVM);
            }
            else
            {
                ServicesVM.Services = _unitOfWork.Services.GetFirstOrDefault(u => u.Id == Id);
                return View(ServicesVM);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertS(ServicesVM obj)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;

                if (obj.Services.Id == 0)
                {
                    _unitOfWork.Services.Add(obj.Services);
                }
                else
                {
                    _unitOfWork.Services.Update(obj.Services);
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
            return View();

        }

       




    }


}
