using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
   public  class FolderConfiguration : EntityTypeConfiguration<Folder>
    {
        public FolderConfiguration() {
            HasRequired<JobRequest>(t => t.jobRequest).WithMany(t => t.folders).HasForeignKey(t => t.jobRequestId).WillCascadeOnDelete(true);


        }
    }
}
