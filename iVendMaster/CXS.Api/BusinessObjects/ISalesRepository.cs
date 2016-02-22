using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CXS.Api.Business;
using Microsoft.AspNet.Mvc;

namespace CXS.Api.BusinessObjects
{
   public interface ISalesRepository
    {
        IActionResult CreateSaleTransaction(TrxTransaction trxTransaction);


    }
}
