using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CXS.Api.Business;
using Microsoft.AspNet.Mvc;
using System.Net;


namespace CXS.Api.BusinessObjects
{
    public class SalesRepository:ISalesRepository
    {
        private readonly IvendDbContext _dbContext;

        public SalesRepository(IvendDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public IActionResult CreateSaleTransaction(TrxTransaction trxTransaction)
        {
            try
            {
                _dbContext.TrxTransaction.Add(trxTransaction);
                _dbContext.SaveChanges();
                return new HttpStatusCodeResult((int)HttpStatusCode.Created);
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }
    }
}
