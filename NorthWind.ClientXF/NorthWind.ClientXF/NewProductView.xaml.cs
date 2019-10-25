using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthWind.ClientXF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewProductView : ContentPage
	{
		public NewProductView ()
		{
			InitializeComponent ();
		}

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            Data.ProductManager PM = new Data.ProductManager();

           await PM.Add(
                new Data.Product
                {
                    ID=int.Parse(entryID.Text),
                    Name = entryName.Text,
                    UnitsInStock = int.Parse(entryUnits.Text),
                    Price = decimal.Parse(entryPrice.Text)
                });
        }
    }
}