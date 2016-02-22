using System.Linq;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;

namespace CXS.Mpos.POS.Windows.Pages
{
    public sealed partial class LandingPage : Page
    {
        private static ResourceLoader loader = new ResourceLoader();

        public LandingPage()
        {
            this.InitializeComponent();

            var vm = new LandingViewModel();
            foreach (var item in vm.LandingItems.SelectMany(l => l))
            {
                item.TitleId = loader.GetString(item.TitleId);
            }

            DataContext = vm;
        }
    }
}
