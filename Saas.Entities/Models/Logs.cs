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
    [Comment("Log Kayıtları")]
    [Table("Log",Schema = "Problem")]
    public class Logs :IEntity
    {
        private String detail;
        private String audit;

        /*
*([Detail],[Date],[Audit])
*
*/
        [Key]
        public int Id { get; set; }

        public string Detail { get => detail; set => detail = value; }
        public DateTime Date { get; set; }
        public string Audit { get => audit; set => audit = value; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Required, DefaultValue(0)]
        public bool Deleted { get ; set ; }
    }
}
