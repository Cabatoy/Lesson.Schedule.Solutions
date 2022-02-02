using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Saas.Entities.Generic;

namespace Saas.Entities.Models
{
    [Comment("FirmaBilgileri")]
    [Table("Company",Schema = "Company")]
    public class Company :IEntity
    {
        private String _fullName;
        private String _taxNumber;

        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get => _fullName; init => _fullName = value; }

        public string? Adress { get; set; }


        [Required, MaxLength(11)]
        public string TaxNumber { get => _taxNumber; init => _taxNumber = value; }
        public string? TaxOffice { get; set; }
        public string? PhoneNumberOne { get; set; }
        public string? PhoneNumberTwo { get; set; }

     


        public string? Description { get; set; }
        public string? DescriptionTwo { get; set; }
        public string? DescriptionThree { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Required, DefaultValue(0)]
        public Boolean Deleted { get ; set ; }
    }
}
