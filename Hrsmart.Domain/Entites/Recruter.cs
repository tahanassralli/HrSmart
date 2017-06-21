using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrsmart.Domain.Entites
{
    public class Recruter
    {

        public int Id { get; set; }

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

        public string Role { get; set; }

        //foreign Key 

       //[ForeignKey("TenantAdmin")]
       //public int TenantAdminId { get; set; }
       //public virtual TenantAdmin TenantAdmin { get; set; }

        //public int RecuterID
        //{
        //    get { return this.EmployeeID; }
        //}


        //Navigation Prop
        virtual public ICollection<Reward> Rewards { get; set; }

        virtual public ICollection<JobOffer> JobOffers { get; set; }
    }
}
