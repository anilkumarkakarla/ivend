using CXS.Mpos.POS.Windows.Pages.NavigationPane;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CXS.Mpos.POS.Windows
{
	sealed partial class App : Application
	{
		public App ()
		{
			Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync (
				Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
				Microsoft.ApplicationInsights.WindowsCollectors.Session);
			this.InitializeComponent ();
			LogStorage.Initialize (new Core.LogConfiguration());
			this.Suspending += OnSuspending;
		}

		protected override void OnLaunched (LaunchActivatedEventArgs e)
		{

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

			PagesShell rootFrame = Window.Current.Content as PagesShell;

			if (rootFrame == null)
			{
				rootFrame = new PagesShell ();

				rootFrame.Language = global::Windows.Globalization.ApplicationLanguages.Languages[0];

				rootFrame.AppFrame.NavigationFailed += OnNavigationFailed;

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
				}

				Window.Current.Content = rootFrame;
			}

			if (rootFrame.AppFrame.Content == null)
			{
				rootFrame.AppFrame.Navigate (typeof (Pages.LoginPage), e.Arguments, new global::Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo ());
			}
			Window.Current.Activate ();
		}

		void OnNavigationFailed (object sender, NavigationFailedEventArgs e)
		{
			throw new Exception ("Failed to load Page " + e.SourcePageType.FullName);
		}

		private void OnSuspending (object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral ();
			deferral.Complete ();
		}
	}
}
