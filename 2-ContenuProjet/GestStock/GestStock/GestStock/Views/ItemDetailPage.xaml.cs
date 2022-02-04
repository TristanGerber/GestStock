using GestStock.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GestStock.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        private void Trigger_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}