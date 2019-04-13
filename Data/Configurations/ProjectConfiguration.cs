using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {

            HasMany<Resource>(y => y.resources).WithMany(o => o.projects).Map(t => t.ToTable("ResouProject"));
            HasRequired<Customer>(a => a.customer).WithMany(t => t.projects).HasForeignKey(e => e.userId)
          .WillCascadeOnDelete(true);

        }
    }
}
