using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CXS.Core.Entities;

namespace CXS.Core.Framework.Data
{
	public interface ISalesRepository : IRepository<TrxTransaction>
	{
		string CreateSaleTransaction(TrxTransaction trxTransaction);
	}
}
