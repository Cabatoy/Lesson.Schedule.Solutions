using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Saas.Entities.Generic;

namespace Saas.Entities.Models
{
    [Comment("Kullanicinin Bağli oldugu Şubeler")]
    [Table("CompanyUserBranches",Schema = "Company")]
    public class CompanyUserBranches :IEntity
    {

        [Key]
        public int Id { get; set; }


        [Display(Name = "CompanyUser")]
        public virtual int CompanyUserId { get; set; }

        [ForeignKey("CompanyUserId"),]

        public virtual CompanyUser CompanyUser { get; set; }


        [Display(Name = "Branch")]
        public virtual int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual CompanyBranch Branch { get; set ; }


        [Required, DefaultValue(0)]
        public bool IsAdmin { get; set; }
        [Required, DefaultValue(0)]
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
