/* Developper : Tristan Gerber
 * Place : ETML, N501
 * Project creation date : 27.01.2022
 * Last updated : 24.03.2022 */

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

            // Registering routes makes it so that they can be accessible in Object form
            Routing.RegisterRoute(nameof(ArticleDetailPage), typeof(ArticleDetailPage));
            Routing.RegisterRoute(nameof(BorrowDetailPage), typeof(BorrowDetailPage));
            Routing.RegisterRoute(nameof(ReturnDetailPage), typeof(ReturnDetailPage));
            Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
            Routing.RegisterRoute(nameof(ProductsPage), typeof(ProductsPage));
            Routing.RegisterRoute(nameof(ArticlesPage), typeof(ArticlesPage));
        }
        /// <summary>
        /// When an user presses on Disconnect, redirects him to the LoginPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
