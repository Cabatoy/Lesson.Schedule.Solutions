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
    [Comment("Firma şubeleri")]
    [Table("CompanyBranch",Schema = "Company")]
    public class CompanyBranch :IEntity
    {
        private Company company;
        private String fullName;

        [Key]
        public int Id { get; set; }

        [Display(Name = "Company")]
        public virtual int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get => company; set => company = value; }

        [Required]
        public string FullName { get => fullName; set => fullName = value; }

        [Required, DefaultValue(0)]
        public bool Deleted { get; set; }
        public string? Description { get; set; }
        public string? DescriptionTwo { get; set; }
        public string? DescriptionThree { get; set; }
    }
}
