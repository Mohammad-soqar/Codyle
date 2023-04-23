using CodyleOffical.DataAccess;
using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CodyleOffical.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class ComptypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComptypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CompType> objCompTypeList = _unitOfWork.CompType.GetAll();
            return View(objCompTypeList);
        }

      
        public IActionResult Create()
        {
            return View();
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CompType.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "CompType");
            }
            return View(obj);

        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var compTypeFromDbFirst = _unitOfWork.CompType.GetFirstOrDefault(u => u. Id == Id);

            if (compTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(compTypeFromDbFirst);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CompType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CompType.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

       
    }
}
