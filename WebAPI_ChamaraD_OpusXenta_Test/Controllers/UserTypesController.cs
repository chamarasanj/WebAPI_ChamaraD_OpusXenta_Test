using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;
using DataContractLayer;

namespace WebAPI_ChamaraD_OpusXenta_Test.Controllers
{
    public class UserTypesController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: api/UserTypes
        //public IQueryable<UserType> GetUserTypes()
        //{

        //    List<UserType> listUserType = db.UserTypes.ToList();
        //    return db.UserTypes;
        //}

        public IEnumerable<UserType> GetUserTypes()
        {

            List<UserType> listUserTypes = db.UserTypes.ToList();
            return listUserTypes;
        }

        // GET: api/UserTypes/5
        [ResponseType(typeof(UserType))]
        public IHttpActionResult GetUserType(int id)
        {
            UserType userType = db.UserTypes.Find(id);
            if (userType == null)
            {
                return NotFound();
            }

            return Ok(userType);
        }

     
    }
}