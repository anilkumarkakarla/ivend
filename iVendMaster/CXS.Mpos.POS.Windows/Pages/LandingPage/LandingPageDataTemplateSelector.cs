using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CXS.Mpos.POS.Windows.Pages
{
    class LandingPageDataTemplateSelector : DataTemplateSelector
    {
        public LandingPageDataTemplateSelector()
        {
            MyDayTemplate = null;
            TransactionsTemplate = null;
            LandingItemTemplate = null;
        }

        public DataTemplate MyDayTemplate
        {
            get; set;
        }
        public DataTemplate TransactionsTemplate { get; set; }
        public DataTemplate LandingItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is MyDayItem)
            {
                return MyDayTemplate;
            }
            else if (item is TransactionsItem)
            {
                return TransactionsTemplate;
            }
            else if (item is LandingItem)
            {
                return LandingItemTemplate;
            }
            return base.SelectTemplateCore(item, container);
        }
    }
}
