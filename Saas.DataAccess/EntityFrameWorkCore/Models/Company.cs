using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.EntityFrameworkCore;

namespace Saas.DataAccess.EntityFrameWorkCore.Models
{
    [Comment("FirmaBilgileri")]
    public class Company
    {
        public int Id { get; set; }

       // [EncryptColumn]
        public string FullName { get; set; }
        public string Adress { get; set; }
      
       // [EncryptColumn]
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string PhoneNumberOne { get; set; }
        public string PhoneNumberTwo { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public string DescriptionTwo { get; set; }
        public string DescriptionThree { get; set; }

    }
}
