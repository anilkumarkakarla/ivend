using CXS.Core.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXS.PosCommon
{
	public class CustomerDispatcher
		: Dispatcher<CustomerService, CustomerService, ICustomerRepository>
	{
	}
}
