using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sem3OnlineHealthInsuranceMgmt.Models;
using Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;
using Sem3OnlineHealthInsuranceMgmt.Utilities;
using Sem3OnlineHealthInsuranceMgmt.ViewModels;

namespace Sem3OnlineHealthInsuranceMgmt.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class InsuranceController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public InsuranceController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        List<Insurance> objInsuranceList = _unitOfWork.Insurance.GetAll(includeProperties:"Category").ToList();
        
        return View(objInsuranceList);
    }

    public IActionResult Upsert(int? id)
    {
        InsuranceVM insuranceVM = new()
        {
            CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
            Insurance = new Insurance()
        };
        if (id == null || id == 0)
        {
            //create
            return View(insuranceVM);
        }
        else
        {
            //update
            insuranceVM.Insurance = _unitOfWork.Insurance.Get(u=>u.Id==id);
            return View(insuranceVM);
        }
    }

    [HttpPost]
    public IActionResult Upsert(InsuranceVM insuranceVM, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string insurancePath = Path.Combine(wwwRootPath, @"images/insurance");

                if (!string.IsNullOrEmpty(insuranceVM.Insurance.ImageUrl))
                {
                    //delete image
                    var oldImagePath = Path.Combine(wwwRootPath, insuranceVM.Insurance.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                
                using (var fileStrem = new FileStream(Path.Combine(insurancePath, fileName),FileMode.Create))
                {
                    file.CopyTo(fileStrem);
                }
                insuranceVM.Insurance.ImageUrl = @"/images/insurance/" + fileName;
            }

            if (insuranceVM.Insurance.Id == 0)
            {
                _unitOfWork.Insurance.Add(insuranceVM.Insurance);
            }
            else
            {
                _unitOfWork.Insurance.Update(insuranceVM.Insurance);
            }
            _unitOfWork.Save();
            TempData["success"] = "Insurance created successfully.";
            return RedirectToAction("Index");   
        }
        else
        {
            insuranceVM.CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            return View(insuranceVM);
        }
    }

    // public IActionResult Delete(int? id)
    // {
    //     if (id == null || id == 0)
    //     {
    //         return NotFound();
    //     }
    //     Insurance? insuranceFromDb = _unitOfWork.Insurance.Get(u => u.Id == id );
    //     if (insuranceFromDb == null)
    //     {
    //         return NotFound();
    //     }
    //     return View(insuranceFromDb);
    // }
    //
    // [HttpPost, ActionName("Delete")]
    // public IActionResult DeletePOST(int? id)
    // {
    //     Insurance? obj = _unitOfWork.Insurance.Get(u => u.Id == id );
    //     if (obj == null)
    //     {
    //         return NotFound();
    //     }
    //     _unitOfWork.Insurance.Remove(obj);
    //     _unitOfWork.Save();
    //     TempData["success"] = "Insurance delete successfully.";
    //     return RedirectToAction("Index");
    // }

    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Insurance> objInsuranceList = _unitOfWork.Insurance.GetAll(includeProperties:"Category").ToList();
        return Json(new { data = objInsuranceList });
    }

    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var insuranceToBeDelete = _unitOfWork.Insurance.Get(u => u.Id == id);
        if (insuranceToBeDelete == null)
        {
            return Json(new {success = false, message = "Error while deleting insurance."});
        }
        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, insuranceToBeDelete.ImageUrl.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }
        _unitOfWork.Insurance.Remove(insuranceToBeDelete);
        _unitOfWork.Save();
        List<Insurance> objInsuranceList = _unitOfWork.Insurance.GetAll(includeProperties:"Category").ToList();
        return Json(new { data = objInsuranceList });
    }

    #endregion
    
}