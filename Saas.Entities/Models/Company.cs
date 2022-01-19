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
        public int Id { get; set; }
      
        [Required]
        public string FullName { get; set; }

        public string Adress { get; set; }


        [Required, MaxLength(11)]
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string PhoneNumberOne { get; set; }
        public string PhoneNumberTwo { get; set; }

        [DefaultValue(0)]
        public bool Deleted { get; set; }

        public string Description { get; set; }
        public string DescriptionTwo { get; set; }
        public string DescriptionThree { get; set; }

    }
}
