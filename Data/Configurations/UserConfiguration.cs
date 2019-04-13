using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
   public  class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration() {


            Map<Customer>(e => e.Requires("role").HasValue("Customer"));
            Map<Resource>(e => e.Requires("role").HasValue("Resource"));
            Map<Admin>(e => e.Requires("role").HasValue("Admin"));
        }
    }
}
