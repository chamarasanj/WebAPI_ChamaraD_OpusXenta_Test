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
    public class UsersController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> userList = db.Users.ToList();
          
            return userList;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        //public IHttpActionResult GetUser(int id)
       public HttpResponseMessage GetUser(int id)
        {
            APIResult objAPIResultmessage = new APIResult();
            objAPIResultmessage.Message = "";

            User user = null;
            try
            {
                user = db.Users.Find(id);
            }
            catch (Exception ex)
            {
                objAPIResultmessage.Message = objAPIResultmessage.Message + ", " + ex.Message;
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, objAPIResultmessage, Configuration.Formatters.JsonFormatter);
            }

            if (user == null)
            {
               //return NotFound();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, objAPIResultmessage, Configuration.Formatters.JsonFormatter);
            }

            // return Ok(user);
            return Request.CreateResponse(HttpStatusCode.OK, user, Configuration.Formatters.JsonFormatter);
        }


        // public IHttpActionResult PutUser(User user)
        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            if (user.UserTypeID != 0)
            {
                user.UserTypeName = db.UserTypes.Find(user.UserTypeID).UserTypeName;
            }

        


            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.UserID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            if(user.UserTypeID!=0)
            {
                user.UserTypeName = db.UserTypes.Find(user.UserTypeID).UserTypeName;
            }


         


            db.Users.Add(user);
            
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}