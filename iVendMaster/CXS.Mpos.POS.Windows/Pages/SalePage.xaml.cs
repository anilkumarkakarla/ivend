using CXS.Mpos.POS.Windows.Pages;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
namespace CXS.Mpos.POS.Windows
{
    public sealed partial class SalePage : Page
    {
        List<ProductItem> ProductItemsList;
       

        public SalePage()
        {
            GetProductItems();
            this.DataContext = ProductItemsList;
            this.InitializeComponent();
        }

        public List<ProductItem> GetProductItems()
        {
            List<ProductItem> ProductItemsList = new List<ProductItem>();
            ProductItemsList.Add(new ProductItem { Id = "100101", ProductName = "Man`s shirt" });
            ProductItemsList.Add(new ProductItem { Id = "100102", ProductName = "Girl`s skirt" });
            ProductItemsList.Add(new ProductItem { Id = "100103", ProductName = "Woman`s sweater" });
            ProductItemsList.Add(new ProductItem { Id = "100104", ProductName = "Man`s socks" });
            ProductItemsList.Add(new ProductItem { Id = "100105", ProductName = "Man`s pants" });
            ProductItemsList.Add(new ProductItem { Id = "100106", ProductName = "Woman`s shoes" });
            ProductItemsList.Add(new ProductItem { Id = "100107", ProductName = "Boy`s sweater" });
            this.ProductItemsList = ProductItemsList;
            return ProductItemsList;
        }

        private void ProductListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(ProductDetailsScreen), e.ClickedItem);
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            List<ProductItem> searchResult = new List<ProductItem>();
            foreach (ProductItem eachItem in ProductItemsList)
            {
                if ((eachItem.ProductName.Contains(sender.Text) == true)|| (eachItem.Id.Contains(sender.Text) == true))
                {
                    searchResult.Add(eachItem);
                }
            }
            searchResult.Sort((c1, c2) => c1.Id.CompareTo(c2.Id));
            this.DataContext = searchResult;

        }


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
        }


        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
            }
            else
            {
            }
        }
        private void Cell_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }
    }
}
