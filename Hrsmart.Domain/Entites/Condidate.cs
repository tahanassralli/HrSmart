using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrsmart.Domain.Entites
{
   public class Condidate
    {
        public int CondidateID { get; set; }


        [Required]
        // Allow up to 40 uppercase and lowercase  
        // characters. Use custom error.
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
             ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }

        [Required]
        // Allow up to 40 uppercase and lowercase  
        // characters. Use custom error.
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
             ErrorMessage = "Characters are not allowed.")]
        public string LastName { get; set; }


        [Required]
        public string Status { get; set; }


        [Required, EmailAddress]
        public string Email { get; set; }


        [Phone]
        public string Phone { get; set; }

        virtual public ICollection<Interview> Interviews { get; set; }
        virtual public ICollection<JobOffer> JobOffers { get; set; }
        public int ReferringEmplyeeId { get; set; }
        [ForeignKey("ReferringEmplyeeId ")]
        // public virtual Condidate Condiadte { get; set; }
        public virtual RefferingEmployee ReferringEmployee { get; set; }
    }

    
}
