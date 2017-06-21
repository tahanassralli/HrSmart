using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Hrsmart.Domain.Entites;


namespace HrSmart.Data.Configurations
{
   public class InterviewConfigurations : EntityTypeConfiguration<Interview>
    {
        public InterviewConfigurations()
        {
            //Property(e => e.Interviewdate.).IsRequired();
            Property(e => e.Level).IsRequired();

            //One To Many
            HasRequired(p => p.Condidate)
                .WithMany(c => c.Interviews)
                .HasForeignKey(p => p.CondidateId)
                .WillCascadeOnDelete(false);



        }
    }
}
