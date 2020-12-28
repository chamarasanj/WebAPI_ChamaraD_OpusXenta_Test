using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ClientWebApp_OpusXenta_Test_ChamaraD.Models;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Controllers
{
    public class SecurityProfileController : Controller
    {
        // GET: SecurityProfile
        public ActionResult Index()
        {
            IEnumerable<SecurityProfileModelView> secProfileList;

            try
            {
                HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("SecurityProfiles").Result;
                secProfileList = responseMsg.Content.ReadAsAsync<IEnumerable<SecurityProfileModelView>>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }

            return View(secProfileList);
        }

        // GET: SecurityProfile/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("SecurityProfiles/" + id.ToString()).Result;

            SecurityProfileModelView ObjSecProfile = null;

            try
            {
                ObjSecProfile = responseMsg.Content.ReadAsAsync<SecurityProfileModelView>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(ObjSecProfile);
        }

        // GET: SecurityProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecurityProfile/Create
        [HttpPost]
        public ActionResult Create(SecurityProfileModelView objSecurityProf)
        {
            try
            {
                HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.PostAsJsonAsync("SecurityProfiles", objSecurityProf).Result;
                TempData["SuccessMessage"] = "Successfully Saved";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: SecurityProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SecurityProfile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SecurityProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SecurityProfile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
