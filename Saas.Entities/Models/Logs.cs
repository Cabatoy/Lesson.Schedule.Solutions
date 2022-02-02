using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Saas.Entities.Generic;

namespace Saas.Entities.Models
{
    [Comment("Log Kayıtları")]
    [Table("Log",Schema = "Problem")]
    public class Logs :IEntity
    {
        private String _detail;
        private String _audit;

        /*
*([Detail],[Date],[Audit])
*
*/
        [Key]
        public int Id { get; set; }

        public string Detail { get => _detail; set => _detail = value; }
        public DateTime Date { get; set; }
        public string Audit { get => _audit; set => _audit = value; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Required, DefaultValue(0)]
        public bool Deleted { get ; set ; }
    }
}
