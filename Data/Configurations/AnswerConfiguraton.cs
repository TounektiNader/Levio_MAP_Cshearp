using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class AnswerConfiguraton : EntityTypeConfiguration<Answers>
    {
        public AnswerConfiguraton()
        {
            HasRequired<Test>(t => t.Test).WithMany(t => t.answers).HasForeignKey(t => t.idTest).WillCascadeOnDelete(true); 
            HasRequired<Resource>(t => t.resource).WithMany(t => t.answers).HasForeignKey(t => t.idUser).WillCascadeOnDelete(true); 



        }

    }
}
