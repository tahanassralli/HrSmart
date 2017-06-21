using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrsmart.Domain.Entites
{
   public class UserInterface
    {

        [Key]
        public int UserInterfaceID { get; set; }
        // a verifier le type d'attribu logo
        [Required]
        public string Logo { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        // Allow up to 40 uppercase and lowercase  
        // characters. Use custom error.
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }


        ////foreign Key 
        ///public int? TenantAdminID { get; set; }
        //[ForeignKey("TenantAdminID ")]
        //[ForeignKey("TenantAdmin")]
        // public int TenantAdminId { get; set; }

        public virtual ICollection<TenantAdmin> TenantAdmins { get; set; }
    }
}
