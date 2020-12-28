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
    public class SecurityProfilesController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: api/SecurityProfiles
        public IQueryable<SecurityProfile> GetSecurityProfiles()
        {
            return db.SecurityProfiles;
        }

        // GET: api/SecurityProfiles/5
        [ResponseType(typeof(SecurityProfile))]
        public IHttpActionResult GetSecurityProfile(int id)
        {
            SecurityProfile securityProfile = db.SecurityProfiles.Find(id);
            if (securityProfile == null)
            {
                return NotFound();
            }

            return Ok(securityProfile);
        }

        // PUT: api/SecurityProfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSecurityProfile(int id, SecurityProfile securityProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != securityProfile.SecurityProfileID)
            {
                return BadRequest();
            }

            db.Entry(securityProfile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecurityProfileExists(id))
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

        // POST: api/SecurityProfiles
        [ResponseType(typeof(SecurityProfile))]
        public IHttpActionResult PostSecurityProfile(SecurityProfile securityProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SecurityProfiles.Add(securityProfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = securityProfile.SecurityProfileID }, securityProfile);
        }

        // DELETE: api/SecurityProfiles/5
        [ResponseType(typeof(SecurityProfile))]
        public IHttpActionResult DeleteSecurityProfile(int id)
        {
            SecurityProfile securityProfile = db.SecurityProfiles.Find(id);
            if (securityProfile == null)
            {
                return NotFound();
            }

            db.SecurityProfiles.Remove(securityProfile);
            db.SaveChanges();

            return Ok(securityProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SecurityProfileExists(int id)
        {
            return db.SecurityProfiles.Count(e => e.SecurityProfileID == id) > 0;
        }
    }
}