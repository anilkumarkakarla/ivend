
using System.Collections.ObjectModel;

namespace CXS.Mpos.POS.Windows.Pages.CustomersPage
{
    public class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

       public Customer(string firstname, string lastname, string address, string phone)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Address = address;
            this.Phone = phone;
        }
    }
}