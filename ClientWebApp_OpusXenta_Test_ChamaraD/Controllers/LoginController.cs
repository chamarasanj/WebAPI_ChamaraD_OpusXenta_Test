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
    public class LoginController : Controller
    {
        // GET: Login
       
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserViewModel user)
        {
            bool isValidUser = IsValidUser(user);

            if (isValidUser)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                TempData["InvalidLogin"] = "Invalid Credentials";
                return View(user);
            }
        }

        public bool IsValidUser(UserViewModel user)
        {
            if (user.LoginEmail == null || user.Password == null)
            {
                return false;
            }

          
            IEnumerable<UserViewModel> users;
            IEnumerable<UserTypeViewModel> userTypes;
          

            try
            {
                HttpResponseMessage responseMsg = ConsumeWebAPI.WebApiClient.GetAsync("Users").Result;
                users = responseMsg.Content.ReadAsAsync<IEnumerable<UserViewModel>>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }


            bool IsUserExists = users.Any(u => u.LoginEmail.ToLower() == user.LoginEmail.ToLower() && u.IsActive && u.Password == user.Password);

            if (IsUserExists)
            {

                try
                {
                    //Assigning logged user login email to session
                    UserViewModel objLoggedUser = users.Where(u => u.LoginEmail.ToLower() == user.LoginEmail.ToLower() && u.IsActive && u.Password == user.Password).FirstOrDefault();
                    Session["LoggedUserEmail"] = objLoggedUser.LoginEmail;

                    //Assigning logged user's user type to session
                    HttpResponseMessage responseMsgUserType = ConsumeWebAPI.WebApiClient.GetAsync("UserTypes").Result;
                    userTypes = responseMsgUserType.Content.ReadAsAsync<IEnumerable<UserTypeViewModel>>().Result;
                    Session["UserType"] = userTypes.Where(u => u.ID == objLoggedUser.UserTypeID).FirstOrDefault().UserTypeName;

                  

                    return true;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                return false;
            }
        }

    


    }
}