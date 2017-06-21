using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrsmart.Domain.Entites
{
  public  class JobOffer
    {
        public int JobOfferID { get; set; }

        [Required]
        public string NameJobOffer { get; set; }
        [Required]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }


        [Required]
        public int PointGet { get; set; }

        //foreign Key 
        public int RecuterID { get; set; }
        [ForeignKey("RecuterID ")]
        public virtual Recruter Recuter { get; set; }


        //Navigation Prop
        virtual public ICollection<RefferingEmployee> ReferringEmployees { get; set; }
        virtual public ICollection<Condidate> Condidates { get; set; }
    }
}
