using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CXS.Api.Business;
using Microsoft.AspNet.Mvc;

namespace CXS.Api.BusinessObjects
{
    public interface IProductRepository
    {
        IActionResult CreateProduct(InvProduct _objProduct);

        IActionResult UpdateProduct(long productKey, InvProduct Product);

        IActionResult DeleteProduct(long productKey);


        IEnumerable<InvProduct> GetProductByAll(InvProduct _objprd, string searchOperator);
        IEnumerable<InvProduct> GetProductByAny(string searchField,string searchValue);

        IEnumerable<InvProduct> GetProductByproductKey(long productKey);

        InvProduct GetProductById(string Id);

        IEnumerable<InvProduct> GetProductAll();




    }
}
