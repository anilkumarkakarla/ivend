using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using CXS.Mpos.POS.Windows.Pages.NavigationPane.Controls;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel.Resources;

namespace CXS.Mpos.POS.Windows.Pages.NavigationPane
{
    public sealed partial class PagesShell : Page
    {
        private static ResourceLoader loader = new ResourceLoader();

        public static PagesShell Current = null;

        public PagesShell()
        {

            this.InitializeComponent();

            this.Loaded += (sender, args) =>
            {
                Current = this;

                this.TogglePaneButton.Focus(FocusState.Programmatic);
            };

            this.BackButton.Opacity = 0;

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManager_BackRequested;

            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                this.BackButton.Visibility = Visibility.Collapsed;
            }

        }

        public Frame AppFrame
        {
            get
            {
                return this.frame;
            }
        }

        #region BackRequested Handlers

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            bool handled = e.Handled;
            this.BackRequested(ref handled);
            e.Handled = handled;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            bool ignored = false;
            this.BackRequested(ref ignored);
        }

        private void BackRequested(ref bool handled)
        {

            if (this.AppFrame == null)
                return;

            if (this.AppFrame.CanGoBack && !handled)
            {
                handled = true;
                this.AppFrame.GoBack();
            }
        }

        #endregion

        #region Navigation

        private async void NavMenuList_ItemInvoked(object sender, ListViewItem listViewItem)
        {
            var item = (NavigationMenuItem)((NavigationMenuListView)sender).ItemFromContainer(listViewItem);

            if (item != null)
            {
                if (item.DestinationPage != null)
                {
                    if (item.DestinationPage == typeof(Uri))
                    {
                        Uri url = null;
                        if (Uri.TryCreate(item.Arguments as string, UriKind.Absolute, out url))
                        {
                            await Launcher.LaunchUriAsync(url);
                        }
                    }
                    else if (item.DestinationPage != this.AppFrame.CurrentSourcePageType)
                    {
                        this.AppFrame.Navigate(item.DestinationPage, item.Arguments);
                    }
                }
            }
        }

        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
        }

        private void OnNavigatedToPage(object sender, NavigationEventArgs e)
        {

            if (this.AppFrame.CurrentSourcePageType == typeof(LoginPage))
            {
                SolidColorBrush TransparentColor = new SolidColorBrush();
                SolidColorBrush blackColor = new SolidColorBrush();
                blackColor.Color = global::Windows.UI.Colors.Black;
                TransparentColor.Color = global::Windows.UI.Colors.Transparent;
                ShellTopBarGrid.Background = TransparentColor;
                SignOutButton.Visibility = Visibility.Collapsed;
                HomeButton.Visibility = Visibility.Collapsed;
                SettingsButton.Visibility = Visibility.Visible;
                TogglePaneButton.Foreground = blackColor;
                TogglePaneButton.Visibility = Visibility.Visible;
                this.BackButton.Visibility = Visibility.Collapsed;
                this.BackButton.Opacity = 0;
                TitleTextBlock.Text = "";
            }
            else
            {
                SolidColorBrush grayColor = new SolidColorBrush();
                SolidColorBrush whiteColor = new SolidColorBrush();
                whiteColor.Color = global::Windows.UI.Colors.White;
                grayColor.Color = global::Windows.UI.Colors.Gray;
                ShellTopBarGrid.Background = grayColor;
                SignOutButton.Visibility = Visibility.Visible;
                TogglePaneButton.Foreground = whiteColor;
                HomeButton.Visibility = Visibility.Visible;
                SettingsButton.Visibility = Visibility.Collapsed;
                if (this.AppFrame.CurrentSourcePageType == typeof(LandingPage))
                {
                    TitleTextBlock.Text = "HOME";
                    this.TogglePaneButton.Visibility = Visibility.Visible;
                    this.BackButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.BackButton.Visibility = Visibility.Visible;
                    this.BackButton.Opacity = 1;
                    TitleTextBlock.Text = "";
                    if ((this.AppFrame.CurrentSourcePageType == typeof(CustomersPage.CustomersPage))|| (this.AppFrame.CurrentSourcePageType == typeof(SalePage)))
                    {
                        this.BackButton.Visibility = Visibility.Visible;
                        this.TogglePaneButton.Visibility = Visibility.Collapsed;
                    }
                }
            }

            if (e.Content is Page && e.Content != null)
            {
                var control = (Page)e.Content;
                control.Loaded += Page_Loaded;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ((Page)sender).Focus(FocusState.Programmatic);
            ((Page)sender).Loaded -= Page_Loaded;
            
        }

        #endregion


       

        private void ClosePanel_Click(object sender, global::Windows.UI.Xaml.RoutedEventArgs e)
        {
            RootSplitView.IsPaneOpen = false;
        }

        private void HomeButton_Click(object sender, global::Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (this.AppFrame.CurrentSourcePageType == typeof(LandingPage))
            {
                this.RootSplitView.IsPaneOpen = false;
            }
            else
            {
                this.AppFrame.Navigate(typeof(LandingPage), null);
            }
        }

        private void SynchronizeButton_Click(object sender, global::Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (this.AppFrame.CurrentSourcePageType == typeof(SalePage))
            {
                this.RootSplitView.IsPaneOpen = false;
            }
            else
            {
                this.AppFrame.Navigate(typeof(SalePage), null);
                RootSplitView.IsPaneOpen = false;
            }
        }

        private void SettingsButton_Click(object sender, global::Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (this.AppFrame.CurrentSourcePageType == typeof(SettingsPage))
            {
                this.RootSplitView.IsPaneOpen = false;
            }
            else
            {
                this.AppFrame.Navigate(typeof(SettingsPage), null);
                RootSplitView.IsPaneOpen = false;
            }
        }

        private void SupportButton_Click(object sender, global::Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (this.AppFrame.CurrentSourcePageType == typeof(CustomersPage.CustomersPage))
            {
                this.RootSplitView.IsPaneOpen = false;
            }
            else
            {
                this.AppFrame.Navigate(typeof(CustomersPage.CustomersPage), null);
                RootSplitView.IsPaneOpen = false;
            }
        }

        private void HelpButton_Click(object sender, global::Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.AppFrame.CurrentSourcePageType != typeof(LoginPage))
            {

                this.AppFrame.Navigate(typeof(LoginPage), null);
                RootSplitView.IsPaneOpen = false;
            }
            else
            {
                RootSplitView.IsPaneOpen = false;
            }
        }
    }
}
