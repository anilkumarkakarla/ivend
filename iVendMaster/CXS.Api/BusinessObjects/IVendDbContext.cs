using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using CXS.Api.Business;


namespace CXS.Api.BusinessObjects
{
    

    public class IvendDbContext : DbContext
    {
       

        public IvendDbContext()
        {
              Database.EnsureCreated();
          
        }

      

        public DbSet<InvProduct> Product { get; set; }

        public DbSet<CusCustomer> Customer { get; set; }

        public DbSet<PurPurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurPurchaseOrderDetail> PurPurchaseOrderDetail { get; set; }

        public DbSet<InvInventoryItem> InvInventoryItem { get; set; }

        public DbSet<ArrAccountsReceivable> ArrAccountsReceivable { get; set; }


        public DbSet<CusCustomerGroup> CusCustomerGroup { get; set; }


        public DbSet<CfgAddress> CfgAddress { get; set; }


        public DbSet<CfgCountry> CfgCountry { get; set; }

        public DbSet<CfgState> CfgState { get; set; }

        public DbSet<TrxTransaction> TrxTransaction { get; set; }


        public DbSet<TrxTransactionPayment> TrxTransactionPayment { get; set; }

        public DbSet<TrxTransactionReceipt> TrxTransactionReceipt { get; set; }

        public DbSet<TrxTransactionSaleItem> TrxTransactionSaleItem { get; set; }

        public DbSet<TrxTransactionStatus> TrxTransactionStatus { get; set; }






    }
}
