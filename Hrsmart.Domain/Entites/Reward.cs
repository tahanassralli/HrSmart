using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrsmart.Domain.Entites
{
   public class Reward
    {
        public int RewardID { get; set; }
        public int PointNumberReward { get; set; }




        //foreign Key
        public int RecuterID { get; set; }
        [ForeignKey("RecuterID ")]
        public virtual Recruter Recuter { get; set; }


        public int ReferringEmployeeID { get; set; }
        [ForeignKey("ReferringEmployeeID ")]
        public virtual RefferingEmployee ReferringEmployee { get; set; }
    }
}
