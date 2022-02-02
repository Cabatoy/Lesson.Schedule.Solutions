using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Saas.Entities.Generic;

namespace Saas.Entities.Models
{
    [Comment("Firma şubeleri")]
    [Table("CompanyBranch",Schema = "Company")]
    public class CompanyBranch :IEntity
    {
        private Company _company;
        private String _fullName;

        [Key]
        public int Id { get; set; }

        [Display(Name = "Company")]
        public virtual int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get => _company; set => _company = value; }

        [Required]
        public string FullName { get => _fullName; set => _fullName = value; }

        [Required, DefaultValue(0)]
        public bool Deleted { get; set; }
        public string? Description { get; set; }
        public string? DescriptionTwo { get; set; }
        public string? DescriptionThree { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
