/* Developper : Tristan Gerber
 * Place : ETML, N501
 * Project creation date : 27.01.2022
 * Last updated : 24.03.2022 */

using GestStock.Services;
using Xamarin.Forms;

namespace GestStock
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // Initializes the DatabaseStore
            DatabaseStore.DatabaseStoreInit();

            // Create the AppShell
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
