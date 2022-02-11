﻿using GestStock.Services;
using GestStock.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestStock
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DatabaseStore.Init();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
