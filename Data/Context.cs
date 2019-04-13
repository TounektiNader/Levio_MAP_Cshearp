
using Data.Configurations;
using Data.Conventions;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
   public class Context : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>

    {

        public static Context Create()
        {
            return new Context();
        }
        static Context()
        {
            Database.SetInitializer<Context>(null);
        }
        public Context():base("name = Map2018")
        {

        }
        DbSet<Events> events { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            modelBuilder.Conventions.Add(new DateTimeConvention());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new AvailibityConfig());
            //modelBuilder.Configurations.Add(new ProjectConfiguration());
            modelBuilder.Configurations.Add(new MandateConfiguration());
            modelBuilder.Configurations.Add(new JobRequestConfiguration());
            modelBuilder.Configurations.Add(new AttachmentConfiguration());
            modelBuilder.Configurations.Add(new TestConfiguration());
            modelBuilder.Configurations.Add(new OfferConfiguration());
            modelBuilder.Configurations.Add(new FolderConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguraton());



            modelBuilder.Entity<Resource>().HasMany(s => s.skills);
            modelBuilder.Entity<Skills>().HasMany(s => s.lstresource);


            //    modelBuilder.Entity<JobRequest>().HasRequired(s => s.folder).WithRequiredPrincipal(ad => ad.jobRequest);
            //   modelBuilder.Entity<Folder>().HasRequired(s => s.jobRequest).WithRequiredDependent(ad => ad.folder);

          //  modelBuilder.Entity<Resource>().HasRequired(s => s.skill).WithRequiredPrincipal(ad => ad.resource);
   //            modelBuilder.Entity<Skills>().HasRequired(s => s.resource).WithRequiredDependent(ad => ad.skill);

         //   modelBuilder.Entity<JobRequest>().HasRequired(p => p.folder).WithOptional(p => p.jobRequest);
           modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Availibility>().ToTable("Availibility");
            modelBuilder.Entity<Claim>().ToTable("Claim");
            modelBuilder.Entity<Folder>().ToTable("Folder");
            modelBuilder.Entity<JobRequest>().ToTable("JobRequest");
            modelBuilder.Entity<Mandate>().ToTable("Mandate");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Profil>().ToTable("Profil");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Skills>().ToTable("Skills");


            modelBuilder.Entity<User>().Property(r => r.UserName).HasColumnName("Login");
            //  modelBuilder.Entity<Client>().Property(r => r.Id).HasColumnName("id_User");
            modelBuilder.Entity<User>().Property(r => r.PasswordHash).HasColumnName("password");
            modelBuilder.Entity<IdentityUserRole>()
           .HasKey(r => new { r.UserId, r.RoleId })
           .ToTable("AspNetUserRoles");


        }

        public System.Data.Entity.DbSet<Domain.Entities.Test> Tests { get; set; }


        // ajouter dans le  travail de bechir 
        public System.Data.Entity.DbSet<Domain.Entities.Claim> Claims { get; set; }


    }
}
