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
        [Key]
        public int Id { get; set; }

        [Display(Name = "Company")]
        public virtual int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }


        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PassWordSalt { get; set; }
      
        [Required]
        public byte[] PassWordHash { get; set; }

        [Required, DefaultValue(0),Comment("Company Admin")]
        public bool SysAdmin { get; set; }

        [Required, DefaultValue(0),Comment("Branch Admin")]
        public bool BranchAdmin { get; set; }

        [Required, DefaultValue(0)]
        public bool Deleted { get; set; }
    }
}
