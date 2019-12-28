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
    public class SalesCustomersViewModel : BaseViewModel
    {
        private ApiService apiService;

        // private bool isRefreshing;
        private List<SalesCustomers> SalesCustomerslist;

        
        


        private ObservableCollection<SalesCustomers> sales;

        public ObservableCollection<SalesCustomers> Sales
        {
            get { return this.sales; }
            set { this.SetValue(ref this.sales, value); }

        }



        public SalesCustomersViewModel()
        {
            this.apiService = new ApiService();
            this.LoadSales();
        }
        private async void LoadSales()
        {

            var response = await this.apiService.GetList<SalesCustomers>("https://salesapi.azurewebsites.net", "/api", "/SalesCustomers");
            if (!response.IsSuccess)
            {
                //   this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            this.SalesCustomerslist = (List<SalesCustomers>)response.Result;
            Sales = new ObservableCollection<SalesCustomers>(this.SalesCustomerslist);
          

        }
        #region SEARCH
        private string filter;
        public string Filter
        { 
             get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
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
                this.Sales = new ObservableCollection<SalesCustomers>(
                    this.SalesCustomerslist);
            }
            else
            {
                this.Sales = new ObservableCollection<SalesCustomers>(
                    this.SalesCustomerslist.Where(l => l.RefNum1.Contains(this.Filter) ||
                    l.Custom1.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion


    }
}

