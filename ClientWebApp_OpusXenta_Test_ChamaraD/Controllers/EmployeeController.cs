using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ClientWebApp_OpusXenta_Test_ChamaraD.Models;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeViewModel> empList;

            try
            {
                HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Employees").Result;
                empList = responseMsg.Content.ReadAsAsync<IEnumerable<EmployeeViewModel>>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }

            return View(empList);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Employees/" + id.ToString()).Result;

            EmployeeViewModel ObjEmployeeViewModel = null;

            try
            {
                ObjEmployeeViewModel = responseMsg.Content.ReadAsAsync<EmployeeViewModel>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(ObjEmployeeViewModel);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            IEnumerable<CompanyViewModel> CompaniesList;
            HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Companies").Result;
            CompaniesList = responseMsg.Content.ReadAsAsync<IEnumerable<CompanyViewModel>>().Result.ToList();
            ViewBag.CompaniesList = new SelectList(CompaniesList, "CompanyID", "CompanyName");

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employee)
        {
            try
            {
                HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.PostAsJsonAsync("Employees", employee).Result;
                TempData["SuccessMessage"] = "Successfully Saved";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Employees/" + id.ToString()).Result;

            EmployeeViewModel ObjEmployeeViewModel = null;

            try
            {
                ObjEmployeeViewModel = responseMsg.Content.ReadAsAsync<EmployeeViewModel>().Result;

                IEnumerable<CompanyViewModel> CompaniesList;
                HttpResponseMessage responseMsgComapnies = ConsumeWebAPI.WebApiClient.GetAsync("Companies").Result;
                CompaniesList = responseMsgComapnies.Content.ReadAsAsync<IEnumerable<CompanyViewModel>>().Result.ToList();
                ViewBag.CompaniesList = new SelectList(CompaniesList, "CompanyID", "CompanyName");

            }
            catch (Exception ex)
            {
                throw;
            }
            return View(ObjEmployeeViewModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeView)
        {
            try
            {
                HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.PutAsJsonAsync("Employees/" + employeeView.EmployeeID, employeeView).Result;

                TempData["SuccessMessage"] = "Successfully Updated";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.DeleteAsync("Employees/" + id.ToString()).Result;

            TempData["SuccessMessage"] = "Successfully Deleted";

            return RedirectToAction("Index");
        }

       
    }
}
