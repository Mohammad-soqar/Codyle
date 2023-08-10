using CodyleOffical.DataAccess;
using CodyleOffical.DataAccess.Repository;
using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using CodyleOffical.Utility;
using CodyleOfficial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;


namespace CodyleOffical.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class SpeakerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;
        private readonly ILogger<SpeakerController> _logger;
        public SpeakerController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, ILogger<SpeakerController> logger)
        {
            _unitOfWork = unitOfWork;
            _HostEnvironment = hostEnvironment;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();

        }



        public IActionResult Upsert(int? Id)
        {
            Speaker newSpeaker = new Speaker();

            if (Id != null && Id != 0)
            {
                newSpeaker = _unitOfWork.Speaker.GetFirstOrDefault(u => u.Id == Id);
            }

            return View(newSpeaker);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Speaker obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Starting Upsert action...");

                string wwwRootPath = _HostEnvironment.WebRootPath;
                if (file != null)
                {
                    _logger.LogInformation("File is not null. Proceeding with image upload...");

                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Speaker");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            _logger.LogInformation("Old image found. Deleting...");
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        _logger.LogInformation("Copying file to stream...");
                        file.CopyTo(fileStream);
                    }

                    obj.ImageUrl = @"\Images\Speaker\" + fileName + extension;
                }

                if (obj.Id == 0)
                {
                    _logger.LogInformation("Adding new Speaker...");
                    _unitOfWork.Speaker.Add(obj);
                }
                else
                {
                    _logger.LogInformation("Updating existing Speaker...");
                    _unitOfWork.Speaker.Update(obj);
                }

                _logger.LogInformation("Saving changes to the database...");
                _unitOfWork.Save();

                _logger.LogInformation("Redirecting to Index...");
                return RedirectToAction("Index");
            }

            _logger.LogWarning("ModelState is not valid. Returning to View...");
            return View(obj);
            //if (ModelState.IsValid)
            //{
            //    string wwwRootPath = _HostEnvironment.WebRootPath;
            //    if (file != null)
            //    {
            //        string fileName = Guid.NewGuid().ToString();
            //        var uploads = Path.Combine(wwwRootPath, @"Images\Speaker");
            //        var extension = Path.GetExtension(file.FileName);

            //        if (obj.ImageUrl != null)
            //        {
            //            var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
            //            if (System.IO.File.Exists(oldImagePath))
            //            {
            //                System.IO.File.Delete(oldImagePath);
            //            }
            //        }
            //        using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            //        {
            //            file.CopyTo(fileStream);
            //        }
            //        obj.ImageUrl = @"\Images\Speaker\" + fileName + extension;
            //    }

            //    if (obj.Id == 0)
            //    {

            //        _unitOfWork.Speaker.Add(obj);
            //    }
            //    else
            //    {

            //        // Update the Event object in the unit of work
            //        _unitOfWork.Speaker.Update(obj);
            //    }

            //    // Save changes to the database
            //    _unitOfWork.Save();

            //    return RedirectToAction("Index");
            //}

            //return View(obj);
        }



        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

           
            return View();

        }

      

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var SpeakerList = _unitOfWork.Speaker.GetAll();
            return Json(new { data = SpeakerList });
        }

        [HttpDelete]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _unitOfWork.Speaker.GetFirstOrDefault(u => u.Id == Id);

            if (obj == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }

            var oldImagePath = Path.Combine(_HostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Speaker.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Event deleted successfuly" });
            return RedirectToAction("Index");

            return View(Id);

        }


        #endregion


    }


}
