using System.Collections.Generic;
using CXS.Core.Entities;
using Newtonsoft.Json;
using CXS.Core.Framework.Data;
using System;

namespace CXS.PosCommon
{
	public class PurchaseOrderService : Service, IPurchaseOrderRepository
	{
		public PurchaseOrderService(IAppSettings settings)
			: base(settings)
		{

		}

		public string CreatePurchaseOrderDetails(PurPurchaseOrder _objPurchaseOrder)
		{
			throw new NotImplementedException();
		}

		public string DeletePurchaseOrderDetails(long purchaseOrderKey)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PurPurchaseOrder> GetPurchaseOrderByAll(PurPurchaseOrder _objpur)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PurPurchaseOrder> GetPurchaseOrderByAny(string searchField, string searchValue)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PurPurchaseOrder> GetPurchaseOrderDetailsByVendorName(string venderName)
		{
			throw new NotImplementedException();
		}

		public string UpdatePurchaseOrderDetails(long purchaseOrderKey, PurPurchaseOrder _objPurchaseOrder)
		{
			throw new NotImplementedException();
		}
	}
}
