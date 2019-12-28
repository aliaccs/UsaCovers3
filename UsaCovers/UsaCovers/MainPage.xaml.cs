using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsaCovers.Views;
using Xamarin.Forms;

namespace UsaCovers
{
    public partial class MainPage :ContentPage
    {
      

        public MainPage()
            
        {
            InitializeComponent();
        }
        private async void BtnSalesPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SalesCustomersPage());

        }
        private async void BtnPendingPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PendingOrdersPage());
        }

    }
}
