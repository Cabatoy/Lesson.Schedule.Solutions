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
    [Comment("FirmaBilgileri")]
    [Table("Company",Schema = "Company")]
    public class Company :IEntity
    {
        private String fullName;
        private String taxNumber;

        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get => fullName; init => fullName = value; }

        public string? Adress { get; set; }


        [Required, MaxLength(11)]
        public string TaxNumber { get => taxNumber; init => taxNumber = value; }
        public string? TaxOffice { get; set; }
        public string? PhoneNumberOne { get; set; }
        public string? PhoneNumberTwo { get; set; }

        [Required, DefaultValue(0)]
        public bool Deleted { get; set; }


        public string? Description { get; set; }
        public string? DescriptionTwo { get; set; }
        public string? DescriptionThree { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
