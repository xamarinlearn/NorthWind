using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NorthWind.ClientXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnGetProducts_Clicked(object sender, EventArgs e)
        {
            Data.ProductManager PM = new Data.ProductManager();

            listView.ItemsSource = await PM.GetAllProducts();
        }
    }
}
