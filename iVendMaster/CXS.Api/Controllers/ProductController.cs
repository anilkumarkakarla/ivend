using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CXS.Api.Business;
using CXS.Api.BusinessObjects;
using System.Net;

namespace CXS.Api.Controllers
{
    [Route("iVendAPI/V1.0/[controller]")]
    public class ProductController : Controller
    {
        [FromServices]
        public IProductRepository _repository { get; set; }

        /// <summary>
        /// This method returns the Product Details
        /// </summary>
        /// <param name="Id">Id of Product</param>
        /// <returns>To return Details of Product</returns>
        /// <remarks>Please Provide the Id of Product</remarks>
        [HttpGet("GetProductByID/{Id}")]
        public InvProduct GetProductById(string Id)
        {
            var productDetails = _repository.GetProductById(Id);
            return productDetails;
        }

        /// <summary>
        /// This method returns the List of products 
        /// </summary>
        /// <param name="productKey">productKey of product</param>
        /// <returns>To return List of products Available</returns>
        [HttpGet("GetProductByproductKey/{productKey:long}")]
        public IEnumerable<InvProduct> GetProductByProductKey(long productKey)
        {
            var productDetails = _repository.GetProductByproductKey(productKey);
            return productDetails;
        }


        /// <summary>
        /// This method returns the List of products 
        /// </summary>
       /// <returns>To return List of products Available</returns>
        [HttpGet]
        public IEnumerable<InvProduct> GetProduct()
        {
            var productDetails = _repository.GetProductAll();
            return productDetails;
        }

        
        /// <summary>
        /// This method returns the List of products 
        /// </summary>
        /// <param name="searchField">SearchField is field name of Product</param>
        /// <param name="searchValue">SearchValue is the field value of  Product</param>
        /// <returns>To return List of products Available</returns>
        [HttpGet]
        [Route("GetProductsByAny")]
        public IEnumerable<InvProduct> GetProductDetailsByAny([FromQuery]string searchField, [FromQuery]string searchValue)
        {
            var productDetails = _repository.GetProductByAny(searchField, searchValue);
            return productDetails;
        }

        /// <summary>
        /// This method returns the List of products 
        /// </summary>
        /// <param name="product">Product object is required return list of Products</param>
        /// <param name="searchOperator">searchOperator is the required for search based on search operator provided e.g.(either AND or  OR) </param>
        /// <returns>To return List of products Available</returns>
        [HttpPost("GetProductsByAll/{searchOperator}")]
        public IEnumerable<InvProduct> GetProductDetailsByAll(string searchOperator, [FromBody]InvProduct product)
        {
            var productDetails = _repository.GetProductByAll(product, searchOperator);
            return productDetails;

        }


        /// <summary>
        ///Create a new Product
        /// </summary>
        /// <param name="Product">Product object is required to create a Product</param>
        /// <returns>201</returns>
        [Route("CreateaNewProduct")]
        [HttpPost]
        public IActionResult  CreateProduct([FromBody]InvProduct Product)
        {
            if (ModelState.IsValid)
            {
                var result = _repository.CreateProduct(Product);
                return result;
            }
            else
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        ///Update an existing Product
        /// </summary>
        /// <param name="productKey">productKey is required to update an existing product</param>
        /// <param name="Product">Product object  is required to update a Product</param>
        /// <returns>200</returns>
        [Route("UpdateProduct/{productKey:long}")]
        [HttpPut]
        public IActionResult UpdateProductDetails(long productKey, [FromBody] InvProduct Product)
        {
            if (ModelState.IsValid)
            {
                var result = _repository.UpdateProduct(productKey, Product);
                return result;
            }
            else
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        ///Delete a Product
        /// </summary>
        /// <param name="productKey">productKey is required to delete an existing product</param>
        /// <returns>204</returns>
        [HttpDelete("DeleteProduct/{productKey:long}")]
        public IActionResult DeleteProductDetails(long productKey)
        {
            _repository.DeleteProduct(productKey);
            return new HttpStatusCodeResult((int)HttpStatusCode.NoContent);
        }



    }
}
