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
    public class GetEmployeesForCompanyController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();
        public IEnumerable<Employee> GetEmployees(int id)
        {
            IEnumerable<Employee> EmployeesListForCompany = db.Employees.Where(x => x.CompanyID == id);

            return EmployeesListForCompany;
        }
    }
}
