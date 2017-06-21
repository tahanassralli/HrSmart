using Hrsmart.Domain.Entites;
using HrSmart.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Data
{
    public class HrSmartContext : DbContext
    {
        public HrSmartContext()
            : base("connect")
        {

        }
        public DbSet<TenantAdmin> TenantAdmis { get; set; }
        public DbSet<Recruter> Recruters { get; set; }
        public DbSet<RefferingEmployee> Refferings { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Condidate> Condidates { get; set; }
        public DbSet<UserInterface> UserInterfaces { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Reward> Rewards { get; set; }




       // protected override void OnModelCreating(DbModelBuilder modelBuilder)
       // {
            //If you want to remove all Convetions and work only with configuration :
            //  modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            //modelBuilder.Configurations.Add(new EmployeeConfiguration());
           // modelBuilder.Configurations.Add(new InterviewConfigurations());
            //modelBuilder.Configurations.Add(new JobOfferConfigurations());
           // modelBuilder.Configurations.Add(new TenantConfiguration());
            //modelBuilder.Configurations.Add(new UserInterfaceConfiguration());
           // modelBuilder.Configurations.Add(new RefferingConfiguration());
           // modelBuilder.Configurations.Add(new RecruterConfiguration());

           // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            //modelBuilder.Entity<TenantAdmin>()
            //    .HasKey(t => t.UserInterfaceID);

            //modelBuilder.Entity<UserInterface>()
            // .HasOptional(p => p.TenantAdmin).WithRequired(p => p.UserInterface);

        //}



    }
}
