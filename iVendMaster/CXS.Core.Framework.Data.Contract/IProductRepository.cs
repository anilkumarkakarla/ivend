using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CXS.Core.Entities;

namespace CXS.Core.Framework.Data
{
	public interface IProductRepository
	{
		string CreateProduct(InvProduct _objProduct);

		string UpdateProduct(long productKey, InvProduct Product);

		string DeleteProduct(long productKey);

		IEnumerable<InvProduct> GetProductByAll(InvProduct _objprd);
		IEnumerable<InvProduct> GetProductByAny(string searchField, string searchValue);

		IEnumerable<InvProduct> GetProductByproductKey(long productKey);

		InvProduct GetProductById(string Id);
	}
}
