using MYFirstWebAPI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MYFirstWebAPI1.Controllers
{
    public class ProductController : ApiController
    {
        ProductDBEntities productDBEntities = new ProductDBEntities();
        Product product = new Product();
        // This method would return the list of products
        [HttpGet]
        public IEnumerable<Product> GetProductsList()
        {
            List<Product> products = new List<Product>();
            products= productDBEntities.Products.ToList();
            return products;
        }

        // This method would the product based on the id

        [HttpGet]
        public Product GetProductById(int id)
        {
            product = productDBEntities.Products.Find(id);
            if(product!=null)
            {
                return product;
            }
            return "couldn't find the product";
            
        }

        // This method would the create the product
        [HttpPost]
        public string CreateProduct(Product prod)
        {
            product.ProductName = prod.ProductName;
            product.ProductPrice = prod.ProductPrice;
            productDBEntities.Products.Add(product);
            productDBEntities.SaveChanges();
            return "The product is created";
        }

        // This method would the update the product
        [HttpPut]
        public string UpdateProduct(Product prod)
        {
            product = productDBEntities.Products.Find(prod.ProductId);
            product.ProductName = prod.ProductName;
            product.ProductPrice = prod.ProductPrice;
            productDBEntities.SaveChanges();
            return "The product is updated";
        }

        // This method would the delete the product
        [HttpDelete]
        public string DeleteProduct(int id)
        {
            product = productDBEntities.Products.Find(id);
            productDBEntities.Products.Remove(product);
            productDBEntities.SaveChanges();
            return "The product is deleted";
        }


    }
}
