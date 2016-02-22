using System.Collections.Generic;
using CXS.Core.Entities;
using Newtonsoft.Json;
using CXS.Core.Framework.Data;
using System;

namespace CXS.PosCommon
{
	public class SalesService : Service, ISalesRepository
	{
		public SalesService(IAppSettings settings)
			: base(settings)
		{

		}

		public string CreateSaleTransaction(TrxTransaction trxTransaction)
		{
			throw new NotImplementedException();
		}
	}
}
