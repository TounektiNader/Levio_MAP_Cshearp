using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class OfferConfiguration : EntityTypeConfiguration<OfferJobs>
    {
        public OfferConfiguration()
        {
            HasRequired<Admin>(t => t.admin).WithMany(t => t.JobOffer).HasForeignKey(t => t.userId).WillCascadeOnDelete(true);
        }
    }
}
