using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrsmart.Domain.Entites
{
   public class TenantAdmin
    {

        public int TenantAdminID { get; set; }

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



        [Required, EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
            ErrorMessage = "Characters are not allowed.")]
        public string organisationName { get; set; }
        public string organisationAddress { get; set; }

        public int organisationPhone { get; set; }


        //foreign Key 

        // public int? UserInterfaceID { get; set; }
        //[ForeignKey("UserInterfaceID ")]

       // [ForeignKey("UserInterface")]
        //public int UserInterfaceId { get; set; }

       // public virtual UserInterface UserInterface { get; set; }


        //Navigation Prop
       // public virtual ICollection<RefferingEmployee> Refferings { get; set; }
        public virtual ICollection<Recruter> Recruters { get; set; }

    }
}
