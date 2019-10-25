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
	public partial class ProductDetailView : ContentPage
	{
		public ProductDetailView ()
		{
			InitializeComponent ();
		}

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {

        }
    }
}