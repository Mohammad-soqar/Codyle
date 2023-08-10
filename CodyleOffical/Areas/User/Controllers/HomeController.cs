using AspNetCore.SEOHelper.Sitemap;
using CodyleOffical.DataAccess.Repository;
using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.Extensions.Hosting;
using CodyleOffical.Utility;
using CodyleOfficial.Models.ViewModels;
using static CodyleOffical.Areas.User.Controllers.HomeController;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Policy;
using System;
using CodyleOfficial.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodyleOffical.Areas.User.Controllers
{
    [Area("User")]

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment env, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;

            _logger = logger;
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public IActionResult Index()
        {
            IndexVM mymodel = new IndexVM();
            mymodel.Event = _unitOfWork.Event.GetAll(includeProperties: "Category");
            mymodel.Blog = _unitOfWork.Blog.GetAll(includeProperties: "Category");
            return View(mymodel);
    
        }

        public IActionResult Privacy()
        {
    
            return View();
        }
        public IActionResult RoadMaps()
        {
            return View();
        }
        public IActionResult Events()
        {
            IEnumerable<Event> eventList = _unitOfWork.Event.GetAll(includeProperties: "Category");
            return View(eventList);
        }
        public IActionResult WebDevelopment()
        {
            return View();
        }
        public IActionResult GraphicDesign()
        {
            return View();
        }
        public IActionResult SMManagement()
        {
            return View();
        }

       
        public IActionResult Thankyou()
        {
            return View();
        }
        public IActionResult EventDetails(int eventId)
        {
            EventDetailsVM model = new EventDetailsVM
            {
                ShoppingCart = new ShoppingCart
                {
                    Count = 1,
                    EventId = eventId,
                    Event = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == eventId, includeProperties: "Category")
                },
                Speaker = _unitOfWork.GetSpeakersByEventId(eventId) // Use your implemented method here

            };
            return View(model);
        }


                [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult EventDetails(ShoppingCart shoppingCart)
        {
            shoppingCart.Event = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == shoppingCart.EventId);
            shoppingCart.Price = shoppingCart.Event.Price;

           if (shoppingCart.Price > 0)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingCart.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                    u => u.ApplicationUserId == claim.Value && u.EventId == shoppingCart.EventId);

                if (cartFromDb == null)
                {
                    _unitOfWork.ShoppingCart.Add(shoppingCart);
                    HttpContext.Session.SetInt32(SD.SessionCart,
               _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count);
                }
                else
                {
                    _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
                }
                _unitOfWork.Save();

                return RedirectToAction("Index", "Cart");


            }
            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index", "Cart");

        }


        [Authorize]
        [HttpPost]
        public IActionResult LikeEvent(int eventId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            IdentityUser user = _userManager.GetUserAsync(User).Result;

         
            EventLike existingLike = _unitOfWork.EventLike.GetFirstOrDefault(el => el.EventId == eventId && el.UserId == user.Id);

            if (existingLike == null)
            {
       
                EventLike eventLike = new EventLike
                {
                    EventId = eventId,
                    UserId = user.Id
                };

              
                _unitOfWork.EventLike.Add(eventLike);
                _unitOfWork.Save();

                var @event = _unitOfWork.Event.GetFirstOrDefault(el => el.Id == eventId);
                if (@event != null)
                {
                    @event.NumberOfLikes++;
                    _unitOfWork.Event.Update(@event);
                    _unitOfWork.Save();
                }


            }
            return Ok();

        }


   


        public IActionResult GOOOGLe()
        {
            return Redirect("google1d96ad6a97cad737.html");
        }
        public IActionResult ReserveASeat()
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
            return View(AttendenceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult ReserveASeat(AttendenceVM obj)
        {
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //obj.Attendence.ApplicationUserId = claim.Value;

            //Attendence cartFromDb = _unitOfWork.Attendences.GetFirstOrDefault(
            //        u => u.ApplicationUserId == claim.Value);
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Attendences.Add(obj.Attendence);
                _unitOfWork.Save();
                return RedirectToAction("Thankyou", "Home");
            }
            return View(obj);
        }

        public IActionResult Blogs()
        {
            IEnumerable<Blog> blogList = _unitOfWork.Blog.GetAll(includeProperties: "Category");
            return View(blogList);
        }
        public IActionResult BlogDetails(int id)
        {
            BlogVM BlogVM = new()
            {  
                blog = new()
            };
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                BlogVM.blog = _unitOfWork.Blog.GetFirstOrDefault(u => u.Id == id);

            }

            return View(BlogVM);
        }
        public IActionResult CreateAndDisplayAdsTxtFile()
        {
            
            string wwwRootPath = _env.WebRootPath;
            // Create a new ads.txt file
            string filePath = Path.Combine(wwwRootPath, @"ads\ads.txt");
            string fileContent = "google.com, pub-7382268700986539, DIRECT, f08c47fec0942fa0";
            System.IO.File.WriteAllText(filePath, fileContent);

            // Display the ads.txt file to the user
            return Redirect("/ads.txt");
        }

        public IActionResult Services()
        {
            return View();
        }

       
        public IActionResult CSC()
        {
            IEnumerable<Event> eventList = _unitOfWork.Event.GetAll(includeProperties: "Category");
            return View(eventList);
        }

        public IActionResult CSCClubMembers(int? Id)
        {
            ClubMembersVM ClubMembersVM = new()
            {
                ClubMembers = new(),

            };

            if (Id == null || Id == 0)
            {
                return View(ClubMembersVM);
            }
            else
            {
                ClubMembersVM.ClubMembers = _unitOfWork.ClubMembers.GetFirstOrDefault(u => u.Id == Id);
                return View(ClubMembersVM);
            }
            return View();

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CSCClubMembers(ClubMembersVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ClubMembers.Add(obj.ClubMembers);
                _unitOfWork.Save();
                return RedirectToAction("JoinUskudar", "Home");
            }
            return View(obj);

        }


        public IActionResult JoinUskudar()
        {
            return View();
        }

     
        
        public IActionResult Aboutus()
        {
            return View();
        }


        public IActionResult SignIn()
        {
            return RedirectToAction("SignIn", "forms");
        }

        public IActionResult Checkout()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult CheckSign()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return LocalRedirect("/Identity/Account/Login");
            }
            // If we got this far, something failed, redisplay form
            return NotFound();
        }
    }
}