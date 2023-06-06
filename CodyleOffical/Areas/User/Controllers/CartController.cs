using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace CodyleOffical.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public int TotalPrice { get; set; }

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM()
            {
                ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value, includeProperties: "Event")

            };
            foreach (var cart in ShoppingCartVM.ListCart)
            {

                cart.Price = cart.Event.Price;
                ShoppingCartVM.CartTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int cartId, int change)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
            if (cart == null)
            {
                return BadRequest("Invalid cart item");
            }

            if (change > 0)
            {
                _unitOfWork.ShoppingCart.IncrementCount(cart, change);
            }
            else if (change < 0)
            {
                if (cart.Count <= 1)
                {
                    _unitOfWork.ShoppingCart.Remove(cart);
                }
                else
                {
                    _unitOfWork.ShoppingCart.DecrementCount(cart, -change);
                }
            }
            cart.Event = _unitOfWork.Event.GetFirstOrDefault(u => u.Id == cart.EventId);

            var updatedTotalPrice = cart.Count * cart.Event.Price;
            _unitOfWork.Save();

            // Return updated data as JSON
            var updatedData = new
            {
                cartId = cart.Id,
                count = cart.Count,
                  TotalPrice = updatedTotalPrice
            };
            return Json(updatedData);
        }

        public IActionResult Remove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
            if (cart != null)
            {
                _unitOfWork.ShoppingCart.Remove(cart);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SuccessfulPayment()
        {
            return View();
        }


        //public IActionResult Index()
        //{

        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //    ShoppingCartVM = new ShoppingCartVM()
        //    {
        //        ListCart = _unitOfWork.ShoppingCart.GetAll(u=> u.ApplicationUserId == claim.Value,includeProperties : "Event")

        //    };
        //    foreach (var cart in ShoppingCartVM.ListCart)
        //    {

        //        cart.Price = cart.Event.Price;
        //        ShoppingCartVM.CartTotal += (cart.Price * cart.Count);
        //    }
        //    return View(ShoppingCartVM);
        //}

        //public IActionResult Plus(int cartId)
        //{
        //    var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
        //    _unitOfWork.ShoppingCart.IncrementCount(cart, 1);
        //    _unitOfWork.Save();
        //    return RedirectToAction(nameof(Index));
        //}


        //public IActionResult Minus(int cartId)
        //{
        //    var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
        //    if (cart.Count <= 1)
        //    {
        //        _unitOfWork.ShoppingCart.Remove(cart);

        //    }
        //    else
        //    {
        //        _unitOfWork.ShoppingCart.DecrementCount(cart, 1);
        //        _unitOfWork.Save();
        //    }

        //    return RedirectToAction(nameof(Index));
        //}
        //public IActionResult Remove(int cartId)
        //{
        //    var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
        //    _unitOfWork.ShoppingCart.Remove(cart);
        //    _unitOfWork.Save();
        //    return RedirectToAction(nameof(Index));
        //}






        //public IActionResult SuccessfulPayment()
        //{
        //    return View();
        //}
    }
}
