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

    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;

        public EventController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            EventVM EventVM = new()
            {


                Event = new(),
               
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

                 SponsorList = _unitOfWork.ApplicationCompany.GetAll().Select(i => new SelectListItem
                 {
                     Text = i.Name,
                     Value = i.Id.ToString()
                 }),

                  SpeakerList = _unitOfWork.Speaker.GetAll().Select(i => new SelectListItem
                  {
                      Text = i.Name,
                      Value = i.Id.ToString()
                  }),
            };
            if (Id == null || Id == 0)
            {
                return View(EventVM);
            }
            else
            {
                EventVM.Event = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == Id);
                return View(EventVM);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EventVM obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Events");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Event.Thumbnail != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Event.Thumbnail.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Event.Thumbnail = @"\Images\Events\" + fileName + extension;
                }

                if (obj.Event.Id == 0)
                {
                    // Retrieve the selected sponsor IDs from the form

                    var selectedSponsorIds = Request.Form["Event.ApplicationCompanyId"];
                    var sponsors = _unitOfWork.ApplicationCompany.GetAll().Where(s => selectedSponsorIds.Contains(s.Id.ToString())).ToList();
                    obj.Event.Sponsor = sponsors;



                    var selectedSpeakerIds = Request.Form["Event.SpeakerpId"];
                    var Speakers = _unitOfWork.Speaker.GetAll().Where(s => selectedSpeakerIds.Contains(s.Id.ToString())).ToList();
                    obj.Event.Speakers = Speakers;

                    // Add the Event object to the unit of work
                    _unitOfWork.Event.Add(obj.Event);
                }
                else
                {
                    // Retrieve the selected sponsor IDs from the form
                    var selectedSponsorIds = Request.Form["Event.ApplicationCompanyId"];
                    var sponsors = _unitOfWork.ApplicationCompany.GetAll().Where(s => selectedSponsorIds.Contains(s.Id.ToString())).ToList();
                    obj.Event.Sponsor = sponsors;


                    var selectedSpeakerIds = Request.Form["Event.SpeakerpId"];
                    var Speakers = _unitOfWork.Speaker.GetAll().Where(s => selectedSpeakerIds.Contains(s.Id.ToString())).ToList();
                    obj.Event.Speakers = Speakers;
                    // Update the Event object in the unit of work
                    _unitOfWork.Event.Update(obj.Event);
                }

                // Save changes to the database
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
            var eventList = _unitOfWork.Event.GetAll(includeProperties:"Category");
            return Json(new { data = eventList });
        }

        [HttpDelete]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == Id);

            if (obj == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }

            var oldImagePath = Path.Combine(_HostEnvironment.WebRootPath, obj.Thumbnail.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Event.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Event deleted successfuly" });
            return RedirectToAction("Index");

            return View(Id);

        }


        #endregion


    }


}
