using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using US.Common.Models;
using UsaCovers.Services;
using Xamarin.Forms;

namespace UsaCovers.ViewModels
{
    public class PendingOrdersViewModel : BaseViewModel
    {
        private ApiService apiService;

        private List<PendingOrders> PendingOrderslist;


        private ObservableCollection<PendingOrders> pendingOrders;

        public ObservableCollection<PendingOrders> PendingOrders
        {
            get { return this.pendingOrders; }
            set { this.SetValue(ref this.pendingOrders, value); }

        }
               
        public PendingOrdersViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPendingOrders();
        }
        private async void LoadPendingOrders()
        {

            var response = await this.apiService.GetList<PendingOrders>("https://salesapi.azurewebsites.net", "/api", "/PendingOrders");
            if (!response.IsSuccess)
            {
                //   this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            PendingOrderslist = (List<PendingOrders>)response.Result;
            PendingOrders = new ObservableCollection<PendingOrders>(PendingOrderslist);
           
        }

        #region SEARCH
        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set
            { SetValue(ref this.filter, value);
                this.Search();
            }

        }

        public ICommand SearchCommand
        {
            get

            {
                return new RelayCommand(Search);
            }
        }

        private void Search()

        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.PendingOrders = new ObservableCollection<PendingOrders>(
                    this.PendingOrderslist);
            }
            else
            {
                this.PendingOrders = new ObservableCollection<PendingOrders>(
                    this.PendingOrderslist.Where(l => l.Supplier.ToLower().Contains(this.Filter.ToLower()) ||
                    l.RefNum.ToLower().Contains(this.Filter.ToLower()) || l.Custo.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion



    }
}

