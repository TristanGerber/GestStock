using GestStock.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestStock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}