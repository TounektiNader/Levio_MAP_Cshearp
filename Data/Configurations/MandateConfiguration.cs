using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class MandateConfiguration : EntityTypeConfiguration<Mandate>
    {
        public MandateConfiguration()
        {
            HasKey(t => new { t.projectId, t.userId });
        }
    }
}
