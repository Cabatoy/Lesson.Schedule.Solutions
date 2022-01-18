using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.DataAccess.EntityFrameWorkCore.Generic;

namespace Saas.DataAccess.EntityFrameWorkCore.Models.UserClaims
{
    public class CompanyOperationUserClaim :IEntity
    {
      

        public int Id { get; set; }

        [Display(Name = "CompanyUser")]
        public virtual int CompanyUserId { get; set; }

        [ForeignKey("CompanyUserId")]
        public virtual CompanyUser CompanyUser { get; set; }

      
        [Display(Name = "CompanyOperationClaim")]
        public virtual int CompanyOperationClaimId { get; set; }
       
        [ForeignKey("CompanyOperationClaimId")]
        public virtual CompanyOperationClaim OperationClaim { get; set; }
      
    }
}
