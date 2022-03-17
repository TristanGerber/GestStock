using GestStock.Services;
using GestStock.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GestStock.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClickedAsync);
        }
        public Action DisplayInvalidLoginPrompt;
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public async void OnLoginClickedAsync()
        {
            if (DatabaseStore.CheckUser(username))
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                ConnectionBase.CurrentUser = username;
                await Shell.Current.GoToAsync("//BorrowedArticlesPage");
            }
        }
    }
}