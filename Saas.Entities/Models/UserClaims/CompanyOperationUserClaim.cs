using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Saas.Entities.Generic;

namespace Saas.Entities.Models.UserClaims
{
    [Comment("Kullanici Yetkileri")]
    [Table("CompanyOperationUserClaim",Schema = "Roles")]
    public class CompanyOperationUserClaim :IEntity
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "CompanyUser")]
        public virtual int CompanyUserId { get; set; }

        [ForeignKey("CompanyUserId")]
        public virtual CompanyUser CompanyUser { get; set; }


        [Display(Name = "CompanyOperationClaim")]
        public virtual int CompanyOperationClaimId { get; set; }

        [ForeignKey("CompanyOperationClaimId")]
        public virtual CompanyOperationClaim OperationClaim { get; set; }

        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
