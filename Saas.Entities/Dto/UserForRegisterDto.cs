using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Entities.Generic;

namespace Saas.Entities.Dto
{
    public class UserForRegisterDto :IDto, IEntity
    {
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string Adress { get; set; }

        public UserForRegisterDto()
        {
            CompanyId = 0;
            BranchId = 0;
        }
    }
}
