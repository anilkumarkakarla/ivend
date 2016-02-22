﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CXS.Api.Business;
using Microsoft.AspNet.Mvc;

using System.Net;

namespace CXS.Api.BusinessObjects
{
    public class ProductRepository: IProductRepository
    {
        private readonly IvendDbContext _dbContext;


        public ProductRepository(IvendDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<InvProduct> GetProductByproductKey(long productKey)
        {
            var product = new List<InvProduct>();
            try
            {
                  product = (from c in _dbContext.Product
                  where Convert.ToString(c.ProductKey).Contains(Convert.ToString(productKey))
                  select c).ToList();
              
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return product;


        }


        public IEnumerable<InvProduct> GetProductByAny(string searchField, string searchValue)
        {
            var product = new List<InvProduct>();
            try
            {
                if (searchField == ("ProductKey"))
                {
                    product = (from c in _dbContext.Product
                               where Convert.ToString(c.ProductKey).Contains(searchValue)
                               select c).ToList();
                }
                else
                {
                    product = (from c in _dbContext.Product
                               where c.Description.Contains(searchValue)
                               select c).ToList();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return product;
        }

        public IEnumerable<InvProduct> GetProductByAll(InvProduct _objprd, string searchOperator)
        {
            var product = new List<InvProduct>();
            try
            {
               if (searchOperator.ToUpper() == "AND")
                {
                    if (_objprd.ProductKey != 0 && !string.IsNullOrEmpty(_objprd.Description))
                        product = (from c in _dbContext.Product
                                   where Convert.ToString(c.ProductKey).StartsWith(Convert.ToString(_objprd.ProductKey)) && (c.Description.StartsWith(_objprd.Description))
                                   select c).ToList();
                }
                else if (searchOperator.ToUpper() == "OR")
                {

                    if (_objprd.ProductKey != 0 || !string.IsNullOrEmpty(_objprd.Description))
                        product = (from c in _dbContext.Product
                                   where Convert.ToString(c.ProductKey).StartsWith(Convert.ToString(_objprd.ProductKey)) || (c.Description.StartsWith(_objprd.Description))
                                   select c).ToList();
                }
            }

            catch (Exception exp)
            {
                throw exp;
            }

            return product;
        }

       public InvProduct GetProductById(string Id)
        {
            InvProduct product = new InvProduct();
            try
            {
                product = _dbContext.Product.Where(p => p.Id == Id).FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw exp;
            }
            return product;


        }

        public IEnumerable<InvProduct> GetProductAll()
        {
            var product = new List<InvProduct>();
            try
            {
                product = ((from c in _dbContext.Product
                           select c).Take(10)).ToList();

            }
            catch (Exception exp)
            {
                throw exp;
            }
            return product;



        }

        public IActionResult CreateProduct(InvProduct _objProduct)
        {
            try
            {
                _dbContext.Product.Add(_objProduct);
                _dbContext.SaveChanges();
                return new HttpStatusCodeResult((int)HttpStatusCode.Created);
            }
           catch (Exception exp)
            {
                throw exp;
            }
       }

        public IActionResult UpdateProduct(long productKey, InvProduct Product)
        {
            try
            {
               var prod = _dbContext.Product.Where(p => p.ProductKey == productKey).First();
               if (prod != null)
                {
                    prod.Description = Product.Description;
                    prod.Created = Product.Created;
                    prod.CreatedBy = Product.CreatedBy;
                    prod.Modified = Product.Modified;
                    prod.ModifiedBy = Product.ModifiedBy;
                    prod.IsDeleted = Product.IsDeleted;
                    _dbContext.SaveChanges();
                }
                return new HttpStatusCodeResult((int)HttpStatusCode.OK);
            }
           catch (Exception exp)
            {
                throw exp;
            }
           
        }
        public IActionResult DeleteProduct(long productKey)
        {
            try
            {
                var product = _dbContext.Product.Where(p => p.ProductKey == productKey).First();

                if (product != null)
                {
                    product.IsDeleted = true;
                    if((_dbContext.SaveChanges()>0))
                    {
                        var inventoryItem = from c in _dbContext.InvInventoryItem
                                            where c.ProductKey == productKey
                                            select c;
                        if (inventoryItem != null)
                        {
                            foreach (var items in inventoryItem)
                            {
                                items.IsLocked = true;
                            }
                            _dbContext.SaveChanges();
                        }
                    }
                  }
                return new HttpStatusCodeResult((int)HttpStatusCode.OK);
          }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
