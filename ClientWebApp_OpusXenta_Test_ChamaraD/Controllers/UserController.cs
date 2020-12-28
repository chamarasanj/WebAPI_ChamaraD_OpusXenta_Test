using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ClientWebApp_OpusXenta_Test_ChamaraD.Models;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {

            IEnumerable<UserViewModel> userList;

            try
            {
                HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Users").Result;
                userList = responseMsg.Content.ReadAsAsync<IEnumerable<UserViewModel>>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }

            return View(userList);
        }


        public ActionResult Create()
        {

            try
            {
                IEnumerable<UserTypeViewModel> userTypeList;
                HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("UserTypes").Result;
                userTypeList = responseMsg.Content.ReadAsAsync<IEnumerable<UserTypeViewModel>>().Result.ToList();
                ViewBag.UserTypeList = new SelectList(userTypeList, "ID", "UserTypeName");


                IEnumerable<SecurityProfileModelView> SecurityProfileList;
                HttpResponseMessage responseMsgSecurityProfile = ConsumeWebAPI.WebApiClient.GetAsync("SecurityProfiles").Result;
                SecurityProfileList = responseMsgSecurityProfile.Content.ReadAsAsync<IEnumerable<SecurityProfileModelView>>().Result.ToList();
                ViewBag.SecurityProfileList = new SelectList(SecurityProfileList, "SecurityProfileID", "Name");
            }
            catch (Exception ex)
            {
                throw;
            }


            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            try
            {
                HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.PostAsJsonAsync("Users", user).Result;
                TempData["SuccessMessage"] = "Successfully Saved";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }


        public ActionResult Edit(int id)
        {
            HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Users/" +id.ToString()).Result;

            UserViewModel ObjUserViewModel = null;

            try
            {
                ObjUserViewModel = responseMsg.Content.ReadAsAsync<UserViewModel>().Result;

                IEnumerable<UserTypeViewModel> userTypeList;
                HttpResponseMessage responseMsguserTypeList = ConsumeWebAPI.WebApiClient.GetAsync("UserTypes").Result;
                userTypeList = responseMsguserTypeList.Content.ReadAsAsync<IEnumerable<UserTypeViewModel>>().Result.ToList();
                ViewBag.UserTypeList = new SelectList(userTypeList, "ID", "UserTypeName", ObjUserViewModel.UserTypeID);

               

            }
            catch (Exception ex)
            {
                throw;
            }
            return View(ObjUserViewModel);
        }


        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            try
            {
                HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.PutAsJsonAsync("Users/" + user.UserID, user).Result;

                TempData["SuccessMessage"] = "Successfully Updated";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
           
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage responseMessage = ConsumeWebAPI.WebApiClient.DeleteAsync("Users/" + id.ToString()).Result;

            TempData["SuccessMessage"] = "Successfully Deleted";

            return RedirectToAction("Index");
        }


    }
}