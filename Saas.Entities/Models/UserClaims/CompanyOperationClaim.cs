using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Saas.Entities.Generic;

namespace Saas.Entities.Models.UserClaims
{
    [Comment("Yetkiler")]
    [Table("CompanyOperationClaim",Schema = "Roles")]
    public class CompanyOperationClaim :IEntity
    {
        private String _name;

        [Key]
        public int Id { get; init; }

        [Required]
        public string Name { get => _name; init => _name = value; }

        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
