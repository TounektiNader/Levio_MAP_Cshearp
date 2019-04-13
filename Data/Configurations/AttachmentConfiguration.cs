using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class AttachmentConfiguration : EntityTypeConfiguration<Attachment>
    {
        public AttachmentConfiguration()
        {
            HasRequired<Folder>(t => t.folder).WithMany(t => t.attachments).HasForeignKey(t => t.folderId).WillCascadeOnDelete(true); 

        }

    }
}
