using System;
using System.Collections.Generic;
using System.Text;

namespace UsaCovers.ViewModels
{
    public class MainViewModel
    {
       
       public SalesCustomersViewModel Sales { get; set; }

       public PendingOrdersViewModel PendingOrders { get; set; }


        public MainViewModel()
        {
        this.Sales = new SalesCustomersViewModel();
      this.PendingOrders = new PendingOrdersViewModel();

        }

    }
}
