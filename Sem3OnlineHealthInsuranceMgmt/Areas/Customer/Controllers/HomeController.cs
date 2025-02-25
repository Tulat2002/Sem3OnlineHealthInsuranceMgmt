using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sem3OnlineHealthInsuranceMgmt.Models;
using Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;
using Sem3OnlineHealthInsuranceMgmt.Utilities;

namespace Sem3OnlineHealthInsuranceMgmt.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Insurance> insuranceList = _unitOfWork.Insurance.GetAll(includeProperties:"Category");
        return View(insuranceList);
    }
    
    public IActionResult Details(int insuranceId)
    {
        ShoppingCart cart = new() {
            Insurance = _unitOfWork.Insurance.Get(u => u.Id == insuranceId, includeProperties: "Category"),
            Count = 1,
            InsuranceId = insuranceId
        };
        return View(cart);
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult Details(ShoppingCart shoppingCart)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        shoppingCart.ApplicationUserId = userId;
        
        ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => 
            u.ApplicationUserId == userId && u.InsuranceId == shoppingCart.InsuranceId);
        if (cartFromDb != null)
        {
            //neu shopponh cart co
            cartFromDb.Count += shoppingCart.Count;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Save();
        }
        else
        {
            //add car record
            _unitOfWork.ShoppingCart.Add(shoppingCart);
            _unitOfWork.Save();
            HttpContext.Session.SetInt32(SD.SessionCart,
                _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());
        }
        TempData["Success"] = "Cart updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}