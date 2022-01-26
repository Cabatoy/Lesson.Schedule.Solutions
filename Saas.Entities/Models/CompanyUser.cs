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
    [Comment("Firma Kullanicilari")]
    [Table("CompanyUser",Schema = "Company")]
    public class CompanyUser :IEntity
    {
        private Company company;
        private String fullName;
        private String email;
        private Byte[] passWordHash;
        private Byte[] passWordSalt;
        private List<CompanyUserBranches> userBranches;

        [Key]
        public int Id { get; set; }

        [Display(Name = "Company")]
        public virtual int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get => company; set => company = value; }


        //[Display(Name = "Branch")]
        //public virtual int? BranchId { get; set; }

        //[ForeignKey("BranchId")]
        //public virtual CompanyBranch Branch { get; set; }


        [Required]
        public string FullName { get => fullName; init => fullName = value; }

        [Required]
        public string Email { get => email; init => email = value; }

        [Required]
        public byte[] PassWordSalt { get => passWordSalt; init => passWordSalt = value; }

        [Required]
        public byte[] PassWordHash { get => passWordHash; init => passWordHash = value; }

        [Required, DefaultValue(0), Comment("IsStudent? Yes-No")]
        public bool IsStudent { get; set; }

        [Required, DefaultValue(0), Comment("Company Admin")]
        public bool SysAdmin { get; set; }

        [Required, DefaultValue(0), Comment("Branch Admin")]
        public bool BranchAdmin { get; init; }

        [Required, DefaultValue(0)]
        public bool Deleted { get; set; }

        public virtual List<CompanyUserBranches> UserBranches { get => userBranches; set => userBranches = value; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
