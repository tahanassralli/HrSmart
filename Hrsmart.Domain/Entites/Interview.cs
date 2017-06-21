using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrsmart.Domain.Entites
{
    public class Interview
    {
        public int InterviewID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Interviewdate { get; set; }


        [Required]
        public int Level { get; set; }


        //foreign Key 
        public int? CondidateId { get; set; }
        [ForeignKey("CondidateId ")]
        public virtual Condidate Condidate { get; set; }

    }
}
