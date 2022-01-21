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
        /*
         *([Detail],[Date],[Audit])
         *
         */
        [Key]
        public int Id { get; set; }

        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }

    }
}
