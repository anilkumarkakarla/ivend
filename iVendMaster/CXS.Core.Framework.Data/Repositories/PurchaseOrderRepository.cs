using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using CXS.Core.Entities;


namespace CXS.Core.Framework.Data
{
    public class PurchaseOrderRepository:IPurchaseOrderRepository
    {

        private readonly IvendDbContext _dbContext;


        public PurchaseOrderRepository(IvendDbContext dbContext)
        {
           _dbContext = dbContext;
        }

    public string CreatePurchaseOrderDetails(PurPurchaseOrder _objPurchaseOrder)
        {
          try
            {
                _dbContext.PurchaseOrder.Add(_objPurchaseOrder);
                _dbContext.SaveChanges();
                return HttpStatusCode.Created.ToString();
            }
           catch (Exception exp)
            {
                throw exp;
            }
        }

       public string UpdatePurchaseOrderDetails(long purchaseOrderKey, PurPurchaseOrder _objPurchaseOrder)
        {
           try
            {
                var purchaseOrder = from p in _dbContext.PurchaseOrder
                                    where p.PurchaseOrderKey == purchaseOrderKey
                                    select p;

                if (purchaseOrder != null)
                {
                    foreach (var ord in purchaseOrder)
                    {
                        ord.VendorKey = _objPurchaseOrder.VendorKey;
                        ord.VendorName = _objPurchaseOrder.VendorName;
                        ord.ReferenceNumber = _objPurchaseOrder.ReferenceNumber;
                        ord.DeliveryDate = _objPurchaseOrder.DeliveryDate;
                        ord.Status = _objPurchaseOrder.Status;
                        ord.IsAuthorized = _objPurchaseOrder.IsAuthorized;
                    }
                    if (_dbContext.SaveChanges() > 0)
                    {
                        var orderDetails = (from c in _dbContext.PurPurchaseOrderDetail
                                           where c.PurchaseOrderKey == purchaseOrderKey
                                           select c).ToList();
                        if (orderDetails != null)
                        {
                            foreach (var ord in orderDetails)
                            {
                              _dbContext.PurPurchaseOrderDetail.Remove(ord);
                                                
                            }
                          if (_dbContext.SaveChanges() > 0)
                            {
                                foreach (var purchasedetails in _objPurchaseOrder.PurPurchaseOrderDetail)
                                {
                                    _dbContext.PurPurchaseOrderDetail.Add(purchasedetails);
                                   
                                }
                                _dbContext.SaveChanges();
                            }
                        }
                    }

                }

                return HttpStatusCode.OK.ToString();
            }
           catch (Exception exp)
            {
                throw exp;
            }
        }


        public IEnumerable<PurPurchaseOrder> GetPurchaseOrderByAny(string searchField, string searchValue)
        {
            var purchaseOrderDetails = new List<PurPurchaseOrder>();
            try
            {
                if (searchField == ("VendorKey"))
                {
                    purchaseOrderDetails = (from p in _dbContext.PurchaseOrder
                                            where Convert.ToString(p.VendorKey).StartsWith(searchValue)
                                              join c in _dbContext.PurPurchaseOrderDetail
                                                          on p.PurchaseOrderKey equals c.PurchaseOrderKey into purchseDetails

                                            select new PurPurchaseOrder
                                            {
                                                PurchaseOrderKey = p.PurchaseOrderKey,
                                                VendorKey = p.VendorKey,
                                                VendorName = p.VendorName,
                                                ReferenceNumber = p.ReferenceNumber,
                                                DeliveryDate = p.DeliveryDate,
                                                Status = p.Status,
                                                IsAuthorized = p.IsAuthorized,
                                                PurPurchaseOrderDetail = purchseDetails.ToList()
                                            }).ToList();

                }
                else
                {
                    purchaseOrderDetails = (from p in _dbContext.PurchaseOrder
                                            where p.VendorName.Contains(searchValue)
                                            join c in _dbContext.PurPurchaseOrderDetail
                                                          on p.PurchaseOrderKey equals c.PurchaseOrderKey into purchseDetails

                                            select new PurPurchaseOrder
                                            {
                                                PurchaseOrderKey = p.PurchaseOrderKey,
                                                VendorKey = p.VendorKey,
                                                VendorName = p.VendorName,
                                                ReferenceNumber = p.ReferenceNumber,
                                                DeliveryDate = p.DeliveryDate,
                                                Status = p.Status,
                                                IsAuthorized = p.IsAuthorized,
                                                PurPurchaseOrderDetail = purchseDetails.ToList()
                                            }).ToList();
                }
            }

            catch (Exception exp)
            {
                throw exp;
            }

            return purchaseOrderDetails;

        }

        public IEnumerable<PurPurchaseOrder> GetPurchaseOrderDetailsByVendorName(string venderName)
        {
            var purchaseOrderDetails = new List<PurPurchaseOrder>();
            try
            {
                purchaseOrderDetails = (from p in _dbContext.PurchaseOrder
                                        where p.VendorName.Contains(venderName)
                                        join c in _dbContext.PurPurchaseOrderDetail
                                                      on p.PurchaseOrderKey equals c.PurchaseOrderKey into purchseDetails

                                        select new PurPurchaseOrder
                                        {
                                            PurchaseOrderKey = p.PurchaseOrderKey,
                                            VendorKey = p.VendorKey,
                                            VendorName = p.VendorName,
                                            ReferenceNumber = p.ReferenceNumber,
                                             Status = p.Status,
                                            IsAuthorized = p.IsAuthorized,
                                            PurPurchaseOrderDetail = purchseDetails.ToList()
                                        }).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return purchaseOrderDetails;
        }






        public IEnumerable<PurPurchaseOrder> GetPurchaseOrderByAll(PurPurchaseOrder purchaseOrder)
        {
           var purchaseOrderDetails = new List<PurPurchaseOrder>();
            try
            {
              if (purchaseOrder.VendorKey != 0 && !string.IsNullOrEmpty(purchaseOrder.VendorName))
                    purchaseOrderDetails = (from p in _dbContext.PurchaseOrder
                                       where (p.VendorName.StartsWith(purchaseOrder.VendorName)) && (Convert.ToString(p.VendorKey).StartsWith(Convert.ToString(purchaseOrder.VendorKey))) 
                                        join c in _dbContext.PurPurchaseOrderDetail
                                                     on p.PurchaseOrderKey equals c.PurchaseOrderKey into purchseDetails

                                        select new PurPurchaseOrder
                                       {
                                           PurchaseOrderKey = p.PurchaseOrderKey,
                                           VendorKey = p.VendorKey,
                                           VendorName = p.VendorName,
                                           ReferenceNumber = p.ReferenceNumber,
                                           DeliveryDate = p.DeliveryDate,
                                           Status = p.Status,
                                           IsAuthorized = p.IsAuthorized,
                                          PurPurchaseOrderDetail = purchseDetails.ToList()
                                       }).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
          return purchaseOrderDetails;
        }

     public string DeletePurchaseOrderDetails(long purchaseOrderKey)
        {
           try
            {
                var orderDetails = _dbContext.PurchaseOrder.Where(p => p.PurchaseOrderKey == purchaseOrderKey).First();

                if (orderDetails != null)
                {
                    orderDetails.IsDeleted = true;

                    if ((_dbContext.SaveChanges()  > 0))
                    {
                        foreach (PurPurchaseOrderDetail ord in orderDetails.PurPurchaseOrderDetail)
                        {
                            ord.IsDeleted = true;
                        }
                    }
                  }
                return HttpStatusCode.NoContent.ToString();
            }
          catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}