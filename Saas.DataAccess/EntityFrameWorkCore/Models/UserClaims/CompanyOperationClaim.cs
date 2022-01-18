using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.DataAccess.EntityFrameWorkCore.Generic;

namespace Saas.DataAccess.EntityFrameWorkCore.Models.UserClaims
{
    public class CompanyOperationClaim :IEntity
    {
     
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
