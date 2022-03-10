using GestStock.Views;
using System;
using Xamarin.Forms;

namespace GestStock
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ArticleDetailPage), typeof(ArticleDetailPage));
            Routing.RegisterRoute(nameof(BorrowDetailPage), typeof(BorrowDetailPage));
            Routing.RegisterRoute(nameof(ReturnDetailPage), typeof(ReturnDetailPage));
            Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
            Routing.RegisterRoute(nameof(ProductsPage), typeof(ProductsPage));
            Routing.RegisterRoute(nameof(ArticlesPage), typeof(ArticlesPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
