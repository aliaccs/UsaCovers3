using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace US.Common.Models
{
    public class SalesCustomers
    {
        [Key]
        public int Id { get; set; }

        public string RefNum1 { get; set; }
        public string Custom1 { get; set; }
        public DateTime DateOR { get; set; }
        public DateTime DateSH { get; set; }
        public decimal TotSales { get; set; }
        public decimal TotGen { get; set; }
        public string RF1 { get; set; }
        public decimal RF2 { get; set; }
        public DateTime RF3 { get; set; }
        public string RF4 { get; set; }

        public override string ToString()
        {
            return this.Custom1.ToString();
        }
    }
}
