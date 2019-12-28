using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace US.Common.Models
{
    public class PendingOrders
    {

        [Key]
        public int Key1 { get; set; }

        public string Custo { get; set; }
        public string TotCusto { get; set; }
        public string TType { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string RefNum { get; set; }
        public string Supplier { get; set; }
        public string Item { get; set; }
        public decimal Qty { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }


        public override string ToString()
        {
            return this.Custo.ToString();
        }
    }
}
    

