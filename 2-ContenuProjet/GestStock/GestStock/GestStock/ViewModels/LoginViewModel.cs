/* Developper : Tristan Gerber
 * Place : ETML, N501
 * Project creation date : 27.01.2022
 * Last updated : 24.03.2022 */

using GestStock.Services;
using System;
using Xamarin.Forms;

namespace GestStock.ViewModels
{
    /// <summary>
    /// ViewModel of LoginPage. Contains multiple methods for this page.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        // Declaring variables
        public Command LoginCommand { get; }
        public Action DisplayInvalidLoginPrompt;
        private string username;
        private string password;

        /// <summary>
        /// Username. Typed by the user.
        /// </summary>
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        /// <summary>
        /// Password. Typed by the user.
        /// </summary>
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        /// <summary>
        /// Constructor of LoginViewModel
        /// </summary>
        public LoginViewModel()
        {
            // Command that activates whenever an user clicks on the "Login" button
            LoginCommand = new Command(OnLoginClickedAsync);
        }
        /// <summary>
        /// Execution of the LoginCommand. If the username is in database, redirects the user to BorrowedArticlesPage
        /// </summary>
        public async void OnLoginClickedAsync()
        {
            if (DatabaseStore.CheckUser(username))
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                // Redirection
                ConnectionBase.CurrentUser = username;
                await Shell.Current.GoToAsync("//BorrowedArticlesPage");
            }
        }
    }
}