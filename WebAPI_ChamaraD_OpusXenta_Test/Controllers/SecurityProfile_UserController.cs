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
    public class SecurityProfile_UserController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: api/SecurityProfile_User
        public IQueryable<SecurityProfile_User> GetSecurityProfile_Users()
        {
            return db.SecurityProfile_Users;
        }

        // GET: api/SecurityProfile_User/5
        [ResponseType(typeof(SecurityProfile_User))]
        public IHttpActionResult GetSecurityProfile_User(int id)
        {
            SecurityProfile_User securityProfile_User = db.SecurityProfile_Users.Find(id);
            if (securityProfile_User == null)
            {
                return NotFound();
            }

            return Ok(securityProfile_User);
        }

        // PUT: api/SecurityProfile_User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSecurityProfile_User(int id, SecurityProfile_User securityProfile_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != securityProfile_User.ID)
            {
                return BadRequest();
            }

            db.Entry(securityProfile_User).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecurityProfile_UserExists(id))
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

        // POST: api/SecurityProfile_User
        [ResponseType(typeof(SecurityProfile_User))]
        public IHttpActionResult PostSecurityProfile_User(SecurityProfile_User securityProfile_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                securityProfile_User.UserName = db.Users.Where(x => x.UserID == securityProfile_User.UserID).FirstOrDefault().FirstName;
                securityProfile_User.SecurityProfileName = db.SecurityProfiles.Where(x => x.SecurityProfileID == securityProfile_User.SecurityProfileID).FirstOrDefault().Name;

                db.SecurityProfile_Users.Add(securityProfile_User);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
           

            return CreatedAtRoute("DefaultApi", new { id = securityProfile_User.ID }, securityProfile_User);
        }

        // DELETE: api/SecurityProfile_User/5
        [ResponseType(typeof(SecurityProfile_User))]
        public IHttpActionResult DeleteSecurityProfile_User(int id)
        {
            SecurityProfile_User securityProfile_User = db.SecurityProfile_Users.Find(id);
            if (securityProfile_User == null)
            {
                return NotFound();
            }

            db.SecurityProfile_Users.Remove(securityProfile_User);
            db.SaveChanges();

            return Ok(securityProfile_User);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SecurityProfile_UserExists(int id)
        {
            return db.SecurityProfile_Users.Count(e => e.ID == id) > 0;
        }
    }
}