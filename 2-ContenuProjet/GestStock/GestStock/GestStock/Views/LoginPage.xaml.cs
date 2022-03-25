/* Developper : Tristan Gerber
 * Place : ETML, N501
 * Project creation date : 27.01.2022
 * Last updated : 24.03.2022 */

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GestStock.ViewModels;
using GestStock.Services;

namespace GestStock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel _viewModel;
        public LoginPage()
        {
            // Liaison avec le ViewModel
            BindingContext = _viewModel = new LoginViewModel();

            // Message d'erreur si les informations sont fausses
            _viewModel.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");

            InitializeComponent();

            // Quand l'utilisateur a fini d'écrire le nom d'utilisateur, le programme le redirige vers le mot de passe
            Username.Completed += (object sender, EventArgs e) =>
            {
                _viewModel.Username = Username.Text;
                Password.Focus();
            };

            // Quand l'utilisateur a fini d'écrire le mot de passe, le programme le redirige vers le mot de passe
            Password.Completed += (object sender, EventArgs e) =>
            {
                _viewModel.LoginCommand.Execute(null);
            };
        }
    }
}