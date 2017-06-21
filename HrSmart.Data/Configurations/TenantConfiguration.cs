using Hrsmart.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Data.Configurations
{
    public class TenantConfiguration : EntityTypeConfiguration<TenantAdmin>
    {
        public TenantConfiguration()
        {



            ////One To Many
            //HasRequired(p => p.UserInterface)
            //    .WithMany(c => c.TenantAdminID)
            //    .HasForeignKey(p => p.UserInterfaceID)
            //    .WillCascadeOnDelete(false);
            //One To Many
           // HasRequired(p => p.UserInterface)
               // .WithMany(c => c.TenantAdmins)
               // .HasForeignKey(p => p.UserInterfaceId)
               // .WillCascadeOnDelete(false);

            // HasRequired(a => a.UserInterface).WithRequiredDependent(t => t.TenantAdmin);
            // HasRequired(s => s.UserInterface).WithRequiredDependent(c => c.TenantAdmin).WillCascadeOnDelete(false);
        }
    }
}
