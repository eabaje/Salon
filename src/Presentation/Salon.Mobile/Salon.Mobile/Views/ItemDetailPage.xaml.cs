using Salon.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Salon.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}