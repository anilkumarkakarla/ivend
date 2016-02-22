using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CXS.Mpos.POS.Windows.Pages.CustomerDetails
{

    public sealed partial class CustomerDetailsPage : Page
    {
        public CustomerDetailsPage()
        {
            this.InitializeComponent();
        }

        private void PersonalInfo_Click(object sender, RoutedEventArgs e)
        {
            if (PersonalInfoGrid.Visibility != Visibility.Visible)
            {
                PersonalInfoGrid.Visibility = Visibility.Visible;
            }
            else if (PersonalInfoGrid.Visibility == Visibility.Collapsed)
            {
                PersonalInfoGrid.Visibility = Visibility.Visible;
            }
        }

        private void AddressInfo_Click(object sender, RoutedEventArgs e)
        {
            if (AddressInfoGrid.Visibility != Visibility.Visible)
            {
                AddressInfoGrid.Visibility = Visibility.Visible;
            }
            else if (AddressInfoGrid.Visibility == Visibility.Collapsed)
            {
                AddressInfoGrid.Visibility = Visibility.Visible;
            }
        }
    }

}
