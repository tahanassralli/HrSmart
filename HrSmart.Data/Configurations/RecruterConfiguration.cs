using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hrsmart.Domain.Entites;

namespace HrSmart.Data.Configurations
{
    public class RecruterConfiguration : EntityTypeConfiguration<Recruter>
    {
        public RecruterConfiguration()
        {
           // HasKey(t => t.RecruterID);

            //One To Many
            //HasRequired(p => p.TenantAdmin)
            //.WithMany(c => c.Recruters)
            //.HasForeignKey(p => p.TenantAdminId)
            //.WillCascadeOnDelete(false);
        }
    }
}
