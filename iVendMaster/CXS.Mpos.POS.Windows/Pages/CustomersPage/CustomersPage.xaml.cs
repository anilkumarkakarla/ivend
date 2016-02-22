using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace CXS.Mpos.POS.Windows.Pages.CustomersPage
{
    public sealed partial class CustomersPage : Page
    {
     
        public CustomersPage()
        {
            this.InitializeComponent();

            SetItemSource();
        }
        private void SetItemSource()
        {
            List<Customer> source = new List<Customer>();
            source.Add(new Customer("Joe", "Smith", "US", "48579347594"));
            source.Add(new Customer("Jim", "Johnson", "UK", "3423423423"));
            source.Add(new Customer("Mary", "Robert", "India", "9384394793"));
            source.Add(new Customer("Patricia", "James", "France", "9384394793"));
            source.Add(new Customer("Linda", "Williams", "Italy", "9384394793"));
            source.Add(new Customer("David", "Jones", "US", "9384394793"));
            source.Add(new Customer("Elizabeth", "Martinez", "US", "9384394793"));
            source.Add(new Customer("Richard", "Robinson", "Germany", "9384394793"));
            source.Add(new Customer("Charles", "Clark", "US", "9384394793"));
            source.Add(new Customer("Joseph", "Rodriguez", "France", "9384394793"));
            source.Add(new Customer("Susan", "Lewis", "Italy", "9384394793"));
            source.Add(new Customer("Thomas", "Lee", "US", "9384394793"));
            source.Add(new Customer("Margaret", "Walker", "US", "9384394793"));
            source.Add(new Customer("Christopher", "Hall", "UK", "9384394793"));
            source.Add(new Customer("Lisa", "Allen", "US", "9384394793"));
            source.Add(new Customer("Daniel", "Young", "US", "9384394793"));
            source.Add(new Customer("Paul", "Hernandez", "US", "9384394793"));
            source.Add(new Customer("Karen", "King", "US", "9384394793"));
            source.Add(new Customer("Ruth", "Wright", "US", "9384394793"));
            source.Add(new Customer("Steven", "Lopez", "US", "9384394793"));
            source.Add(new Customer("Edward", "Hill", "US", "9384394793"));
            source.Add(new Customer("Sharon", "Scott", "US", "9384394793"));
            source.Add(new Customer("Brian", "Green", "US", "9384394793"));
            source.Add(new Customer("Michelle", "Ramos", "US", "9384394793"));
            source.Add(new Customer("Ronald", "Mason", "India", "9384394793"));
            source.Add(new Customer("Laura", "Crawford", "US", "9384394793"));
            source.Add(new Customer("Anthony", "Burns", "US", "9384394793"));
            source.Add(new Customer("Sarah", "Gordon", "India", "9384394793"));
            source.Add(new Customer("Kevin", "Hunter", "US", "9384394793"));
            source.Add(new Customer("Kimberly", "Tucker", "US", "9384394793"));
            source.Add(new Customer("Jason", "Dixon", "US", "9384394793"));
            source.Add(new Customer("Deborah", "Mills", "US", "9384394793"));
            source.Add(new Customer("Matthew", "Warren", "US", "9384394793"));
            source.Add(new Customer("Jessica", "Nichols", "US", "9384394793"));
            source.Add(new Customer("Gary", "Knight", "US", "9384394793"));
            source.Add(new Customer("Shirley", "Ferguson", "US", "9384394793"));

            List<AlphaKeyGroup<Customer>> itemSource = AlphaKeyGroup<Customer>.CreateGroups(source,
                CultureInfo.CurrentUICulture,
                s => s.LastName, true);

            ((CollectionViewSource)Resources["CustomersGroups"]).Source = itemSource;
        }

        
    }
}
