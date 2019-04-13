using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class JobRequestConfiguration : EntityTypeConfiguration<JobRequest>
    {
        public JobRequestConfiguration()
        {
            HasRequired<OfferJobs>(t => t.offerJobs).WithMany(t => t.jobRequest).HasForeignKey(t => t.offerId).WillCascadeOnDelete(true);
            HasRequired<Resource>(t => t.resource).WithMany(t => t.jobRequests).HasForeignKey(t => t.userId);

        }
    }
}
