using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthWind.ClientXF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMDPMaster : ContentPage
    {
        public ListView ListView;

        public MainPageMDPMaster()
        {
            InitializeComponent();

            BindingContext = new MainPageMDPMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainPageMDPMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageMDPMenuItem> MenuItems { get; set; }

            public MainPageMDPMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainPageMDPMenuItem>(new[]
                {
                    new MainPageMDPMenuItem { Id = 0, Title = "Products",TargetType=typeof(MainPage) },
                    new MainPageMDPMenuItem { Id = 1, Title = "Nuevo",TargetType=typeof(NewProductView) }
                    
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}