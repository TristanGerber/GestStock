/* Developper : Tristan Gerber
 * Place : ETML, N501
 * Project creation date : 27.01.2022
 * Last updated : 24.03.2022 */

using GestStock.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestStock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerPage : ContentPage
    {
        ScannerViewModel _viewModel;
        public ScannerPage()
        {
            // Liaison avec le ViewModel
            BindingContext = _viewModel = new ScannerViewModel();
            InitializeComponent();
        }
    }
}