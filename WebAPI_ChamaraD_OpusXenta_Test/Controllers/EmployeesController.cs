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
    public class EmployeesController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: api/Employees
      
        public IEnumerable<Employee> GetUsers()
        {
            IEnumerable<Employee> empList = db.Employees.ToList();

            return empList;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public HttpResponseMessage GetEmployee(int id)
        {
            APIResult objAPIResultmessage = new APIResult();
            objAPIResultmessage.Message = "";

            Employee emp = null;
            try
            {
                emp = db.Employees.Find(id);
            }
            catch (Exception ex)
            {
                objAPIResultmessage.Message = objAPIResultmessage.Message + ", " + ex.Message;
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, objAPIResultmessage, Configuration.Formatters.JsonFormatter);
            }

            if (emp == null)
            {
                //return NotFound();
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, objAPIResultmessage, Configuration.Formatters.JsonFormatter);
            }

            // return Ok(user);
            return Request.CreateResponse(HttpStatusCode.OK, emp, Configuration.Formatters.JsonFormatter);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            if (employee.CompanyID != 0)
            {
                employee.CompanyName = db.Companies.Find(employee.CompanyID).CompanyName;
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (employee.CompanyID != 0)
            {
                employee.CompanyName = db.Companies.Find(employee.CompanyID).CompanyName;
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeID }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }


    }
}