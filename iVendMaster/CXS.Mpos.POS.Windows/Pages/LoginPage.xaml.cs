using Windows.ApplicationModel;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CXS.Mpos.POS.Windows.Pages
{
    public sealed partial class LoginPage : Page
    {
        private static ResourceLoader loader = new ResourceLoader();

        public string AppVersion{ get; private set; }

        public LoginPage ()
        {
            var version = Package.Current.Id.Version;
            AppVersion = string.Format(loader.GetString("AppVersion"), version.Major, version.Minor, version.Build, version.Revision);
			this.InitializeComponent ();
            DataContext = this;
        }

        private void SignInButton_Click (object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate (typeof (LandingPage));

        }
    }
}
