using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ClientWebApp_OpusXenta_Test_ChamaraD.Models;
using Newtonsoft.Json;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            IEnumerable<CompanyViewModel> CompanyList;

            try
            {
                HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Companies").Result;
                           
                CompanyList = responseMsg.Content.ReadAsAsync<IEnumerable<CompanyViewModel>>().Result;

            }
            catch (Exception ex)
            {
                throw;
            }

            return View(CompanyList);
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Companies/" + id.ToString()).Result;

            CompanyViewModel ObjCompanyViewModel = null;

            try
            {
                ObjCompanyViewModel = responseMsg.Content.ReadAsAsync<CompanyViewModel>().Result;

                ObjCompanyViewModel.EmployeeList = new List<EmployeeViewModel>();

                HttpResponseMessage comexistsResponseMessage = ConsumeWebAPI.WebApiClient.GetAsync("GetEmployeesForCompany/" + id.ToString()).Result;

                ObjCompanyViewModel.EmployeeList = comexistsResponseMessage.Content.ReadAsAsync<IEnumerable<EmployeeViewModel>>().Result;

                

            }
            catch (Exception ex)
            {
                throw;
            }
            return View(ObjCompanyViewModel);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public JsonResult Create(CompanyViewModel company)
        {
            try
            {
                string newImage = Guid.NewGuid() + Path.GetExtension(company.LogoPath.FileName);

                company.LogoPath.SaveAs(Server.MapPath("~/Images/" + newImage));

       
                Company objCompany = new Company();

                objCompany.CompanyID = company.CompanyID;
                objCompany.Email = company.Email;
                //objCompany.LogoPath = "~/Images/" + newImage;
                objCompany.LogoPath = "";
                objCompany.CompanyName = company.CompanyName;
                objCompany.Website = company.Website;

                HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.PostAsJsonAsync("Companies", objCompany).Result;
                TempData["SuccessMessage"] = "Successfully Saved";

              //  return RedirectToAction("Index");

                return Json(new { Success = true, Message = "Company Is Added Successfully." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
               // return View();

                return Json(new { Success = false, Message = "error in saving." }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Companies/" + id.ToString()).Result;

            CompanyViewModel ObjCompanyViewModel = null;

            try
            {
                ObjCompanyViewModel = responseMsg.Content.ReadAsAsync<CompanyViewModel>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(ObjCompanyViewModel);
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(CompanyViewModel company)
        {
            try
            {
                HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.PutAsJsonAsync("Companies/" + company.CompanyID, company).Result;

                TempData["SuccessMessage"] = "Successfully Updated";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }


        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            int CompanyID = 0;

            CompanyID = id;
            bool IsCompanyAssigned = false;
            IsCompanyAssigned = CheckIfEmployeeTableHasCompanyID(CompanyID);

            if(!IsCompanyAssigned)
            {
                HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.DeleteAsync("Companies/" + CompanyID.ToString()).Result;

                TempData["SuccessMessage"] = "Successfully Deleted";

                return RedirectToAction("Index");

            }
            else
            {
                TempData["DeleteFailed"] = "Sorry, This Company Cannot Be Deleted, Company is Assigned for Employee";
                return View();
            }
        }

        private bool CheckIfEmployeeTableHasCompanyID(int companyID)
        {
            bool IsCompanyAssigned = true;

            IEnumerable<EmployeeViewModel> empList;

            try
            {
                HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Employees").Result;
                empList = responseMsg.Content.ReadAsAsync<IEnumerable<EmployeeViewModel>>().Result;

                EmployeeViewModel objEmployee = empList.FirstOrDefault(x => x.CompanyID == companyID);

                if(objEmployee==null)
                {
                    IsCompanyAssigned = false;
                }
                else
                {
                    IsCompanyAssigned = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return IsCompanyAssigned;
        }
    }
}
