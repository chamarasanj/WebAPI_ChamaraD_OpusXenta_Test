using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataContractLayer;


namespace DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ApplicationDBContext")
        {
        }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<SecurityProfile> SecurityProfiles { get; set; }

        public DbSet<SecurityProfile_User> SecurityProfile_Users { get; set; }
    }
}
