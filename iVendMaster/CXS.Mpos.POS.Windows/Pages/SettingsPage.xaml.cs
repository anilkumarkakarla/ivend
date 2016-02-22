using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CXS.Mpos.POS.Windows.Pages
{
	public sealed partial class SettingsPage : Page
	{
		public SettingsPage ()
		{
			this.InitializeComponent ();
		}

		void ButtonToLoginClick (object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate (typeof (LoginPage));
		}
	}
}
