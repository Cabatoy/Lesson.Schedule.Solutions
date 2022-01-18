using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.DataAccess.EntityFrameWorkCore.Models
{
    public class CompanyUser :IEntity
    {
      

        public int Id { get; set; }
        
        [Display(Name = "Company")]
        public virtual int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
      
        public int LocalId { get; set; }
        public string FullName { get; set; }
      
        [Required]
        public string Email { get; set; }
        [Required]
        public byte[] PassWordSalt { get; set; }
        [Required]
        public byte[] PassWordHash { get; set; }
       
        public bool Deleted { get; set; }
    }
}
