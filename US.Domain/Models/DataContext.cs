using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace US.Domain.Models
{
   public class DataContext :DbContext 
    {
        public DataContext(): base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<US.Common.Models.SalesCustomers> SalesCustomers { get; set; }
        public System.Data.Entity.DbSet<US.Common.Models.PendingOrders> PendingOrders { get; set; }
    }
}
