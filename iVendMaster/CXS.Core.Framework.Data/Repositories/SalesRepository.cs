using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CXS.Core.Entities;
using System.Net;


namespace CXS.Core.Framework.Data
{
	public class SalesRepository : ISalesRepository
	{
		private readonly IvendDbContext _dbContext;

		public SalesRepository(IvendDbContext dbContext)
		{
			_dbContext = dbContext;

		}

		public string CreateSaleTransaction(TrxTransaction trxTransaction)
		{
			try
			{
				_dbContext.TrxTransaction.Add(trxTransaction);
				_dbContext.SaveChanges();
				return HttpStatusCode.Created.ToString();
			}
			catch (Exception exp)
			{
				throw exp;
			}

		}
	}
}
