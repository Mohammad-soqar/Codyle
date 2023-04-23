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


namespace CodyleOffical.Areas.User.Controllers
{
    [Area("User")]

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
           
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
           
                ShoppingCart cartobj = new()
            {
                Count = 1,
                EventId = eventId,
                Event = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == eventId, includeProperties: "Category"),
            };
            
            return View(cartobj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult EventDetails(ShoppingCart shoppingCart)
        {
           if(shoppingCart.Price > 0)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingCart.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                    u => u.ApplicationUserId == claim.Value && u.EventId == shoppingCart.EventId);

                if (cartFromDb == null)
                {
                    _unitOfWork.ShoppingCart.Add(shoppingCart);
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

        public IActionResult FreeEventDetails(int eventId)
        {

            Attendence reserveobj = new()
            {
         
                EventId = eventId,
                Event = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == eventId, includeProperties: "Category"),
                
            };
            return View(reserveobj);
        }

        
     

        //if (cartobj.Price > 0)
        //{
        //   
        //}
        //else if (cartobj.Price == 0)
        //{
        //    return View(attendence);

        //}
        //return NotFound();



        //else if(shoppingCart.Price == 0)
        // {
        //     var claimsIdentity = (ClaimsIdentity)User.Identity;
        //     var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

        //    // Attendence cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
        //     //  u => u.ApplicationUserId == claim.Value && u.EventId == shoppingCart.EventId);

        //     shoppingCart.ApplicationUserId = claim.Value;
        //     return RedirectToAction("Index", "Home");
        // }


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
        //public IActionResult CSCClubMembers(int? Id)
        //{
        //    ClubMembersVM ClubMembersVM = new()
        //    {
        //        ClubMembers = new(),

        //    };

        //    if (Id == null || Id == 0)
        //    {
        //        return View(ClubMembersVM);
        //    }
        //    else
        //    {
        //        ClubMembersVM.ClubMembers = _unitOfWork.ClubMembers.GetFirstOrDefault(u => u.Id == Id);
        //        return View(ClubMembersVM);
        //    }
        //    return View();
           
        //}

        public string CreateSitemapInRootDirectory()
        {
            var list = new List<SitemapNode>();
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/", Frequency = SitemapFrequency.Always });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/Events", Frequency = SitemapFrequency.Always });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/Services", Frequency = SitemapFrequency.Monthly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/RoadMaps", Frequency = SitemapFrequency.Monthly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/Blogs", Frequency = SitemapFrequency.Always });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/Aboutus", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/WebDevelopment", Frequency = SitemapFrequency.Monthly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/GraphicDesign", Frequency = SitemapFrequency.Monthly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/SMManagement", Frequency = SitemapFrequency.Monthly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/Identity/Account/Login", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/FreeEventDetails?eventId=16", Frequency = SitemapFrequency.Weekly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/FreeEventDetails?eventId=14", Frequency = SitemapFrequency.Monthly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/BlogDetails/3", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/BlogDetails/4", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/BlogDetails/6", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/CSC", Frequency = SitemapFrequency.Monthly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codyle.com/User/Home/Privacy", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://codyle.com/Identity/Account/ForgotPassword", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://codyle.com/Identity/Account/Login?ReturnUrl=%2FUser%2FServices%2FUpsert", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://codyle.com/Identity/Account/Login?ReturnUrl=%2FUser%2FServices%2FUpsertS", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://codyle.com/Identity/Account/Register?returnUrl=%2FUser%2FServices%2FUpsert", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://codyle.com/Identity/Account/Register?returnUrl=%2FUser%2FServices%2FUpsertS", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://codyle.com/User/Home/ReserveASeat", Frequency = SitemapFrequency.Monthly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.6, Url = "https://codyle.com/User/Home/CSCClubMembers", Frequency = SitemapFrequency.Monthly });
            new SitemapDocument().CreateSitemapXML(list, _env.ContentRootPath);

            return "sitemap.xml file should be create in root directory";
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CSCClubMembers(ClubMembersVM obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.ClubMembers.Add(obj.ClubMembers);
        //        _unitOfWork.Save();
        //        return RedirectToAction("Thankyou", "Home");
        //    }
        //    return View(obj);

        //}
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