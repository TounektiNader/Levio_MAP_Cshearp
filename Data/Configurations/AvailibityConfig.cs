using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
   public class AvailibityConfig : EntityTypeConfiguration<Availibility>
    {
        public AvailibityConfig()
        {
            Map<Holidays>(e => e.Requires("type").HasValue("Holiday"));
            Map<TimeOff>(e => e.Requires("type").HasValue("TimeOff"));
        }
    }
}
