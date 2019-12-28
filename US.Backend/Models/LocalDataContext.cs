using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using US.Domain.Models;

namespace US.Backend.Models
{
    public class LocalDataContext : DataContext
    {
        public  System.Data.Entity.DbSet<US.Common.Models.SalesCustomers> SalesCustomers { get; set; }

        public  System.Data.Entity.DbSet<US.Common.Models.PendingOrders> PendingOrders { get; set; }
    }
}