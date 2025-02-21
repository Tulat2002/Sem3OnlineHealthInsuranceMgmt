using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sem3OnlineHealthInsuranceMgmt.Models;
using Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;
using Sem3OnlineHealthInsuranceMgmt.Utilities;
using Sem3OnlineHealthInsuranceMgmt.ViewModels;

namespace Sem3OnlineHealthInsuranceMgmt.Controllers;

[Area("Admin")]
// [Authorize(Roles = SD.Role_Admin)]
public class CompanyController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CompanyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
        
        return View(objCompanyList);
    }

    public IActionResult Upsert(int? id)
    {
        if (id == null || id == 0)
        {
            //create
            return View(new Company());
        }
        else
        {
            //update
            Company companyObj = _unitOfWork.Company.Get(u=>u.Id==id);
            return View(companyObj);
        }
    }

    [HttpPost]
    public IActionResult Upsert(Company CompanyObj)
    {
        if (ModelState.IsValid)
        {
            if (CompanyObj.Id == 0)
            {
                _unitOfWork.Company.Add(CompanyObj);
            }
            else
            {
                _unitOfWork.Company.Update(CompanyObj);
            }
            _unitOfWork.Save();
            TempData["success"] = "Company created successfully.";
            return RedirectToAction("Index");   
        }
        else
        {
            return View(CompanyObj);
        }
    }


    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
        return Json(new { data = objCompanyList });
    }

    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var CompanyToBeDelete = _unitOfWork.Company.Get(u => u.Id == id);
        if (CompanyToBeDelete == null)
        {
            return Json(new {success = false, message = "Error while deleting."});
        }
        _unitOfWork.Company.Remove(CompanyToBeDelete);
        _unitOfWork.Save();
        
        return Json(new { success = true, message = "Delete successfully." });
    }

    #endregion
    
}