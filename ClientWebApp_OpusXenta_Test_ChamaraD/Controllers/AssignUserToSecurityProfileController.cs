using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ClientWebApp_OpusXenta_Test_ChamaraD.Models;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Controllers
{
    public class AssignUserToSecurityProfileController : Controller
    {
        // GET: AssignUserToSecurityProfile
        public ActionResult Index()
        {
            IEnumerable<SecurityProfile_UserViewModel> SecurityProfile_UserList;
           // IEnumerable<SecurityProfile_UserViewModel> SecurityProfile_UserListWithNames;

            try
            {
                HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("SecurityProfile_User").Result;
                SecurityProfile_UserList = responseMsg.Content.ReadAsAsync<IEnumerable<SecurityProfile_UserViewModel>>().Result;

            }
            catch (Exception ex)
            {
                throw;
            }

            return View(SecurityProfile_UserList);
        }

        // GET: AssignUserToSecurityProfile/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("SecurityProfile_User/" + id.ToString()).Result;

            SecurityProfile_UserViewModel ObjSecProfile_User = null;

            try
            {
                ObjSecProfile_User = responseMsg.Content.ReadAsAsync<SecurityProfile_UserViewModel>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(ObjSecProfile_User);
        }

        // GET: AssignUserToSecurityProfile/Create
        public ActionResult Create()
        {
            IEnumerable<SecurityProfileModelView> SecProfList;
            HttpResponseMessage responseMsgSecProfList = ConsumeWebAPI.WebApiClient.GetAsync("SecurityProfiles").Result;
            SecProfList = responseMsgSecProfList.Content.ReadAsAsync<IEnumerable<SecurityProfileModelView>>().Result.ToList();
            ViewBag.SecProfList = new SelectList(SecProfList, "SecurityProfileID", "Name");

            IEnumerable<UserViewModel> UserList;
            HttpResponseMessage responseMsgUserList = ConsumeWebAPI.WebApiClient.GetAsync("Users").Result;
            UserList = responseMsgUserList.Content.ReadAsAsync<IEnumerable<UserViewModel>>().Result.ToList();
            ViewBag.UserList = new SelectList(UserList, "UserID", "FirstName");

            return View();
        }

        // POST: AssignUserToSecurityProfile/Create
        [HttpPost]
        public ActionResult Create(SecurityProfile_UserViewModel SecurityProfile_UserViewModel)
        {
            try
            {
                HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.PostAsJsonAsync("SecurityProfile_User", SecurityProfile_UserViewModel).Result;
                TempData["SuccessMessage"] = "Successfully Saved";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: AssignUserToSecurityProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssignUserToSecurityProfile/Edit/5
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

        // GET: AssignUserToSecurityProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssignUserToSecurityProfile/Delete/5
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
