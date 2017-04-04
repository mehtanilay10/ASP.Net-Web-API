using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductEntity;

namespace V5_RestGetRequest.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public IEnumerable<Product> LoadAllProducts()
        {
            using (ProductEntities entity = new ProductEntities())
            {
                return entity.Products.ToList();
            }
        }

        [AcceptVerbs("GET", "POST")]
        public HttpResponseMessage LoadProductWithId(int id)
        {
            using (ProductEntities entity = new ProductEntities())
            {
                Product product = entity.Products.FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with given Id does not exist!");
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
        }


        public HttpResponseMessage Post(Product product)
        {
            try
            {
                using (ProductEntities entity = new ProductEntities())
                {
                    entity.Products.Add(product);
                    entity.SaveChanges();

                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, product);
                    message.Headers.Location = new Uri(Request.RequestUri + product.ProductId.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        public HttpResponseMessage Put([FromBody]int id, [FromUri]Product newProduct)
        {
            try
            {
                using (ProductEntities entity = new ProductEntities())
                {
                    Product existingProduct = entity.Products.FirstOrDefault(x => x.ProductId == id);
                    if (existingProduct == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with Given Id does not exist!");

                    existingProduct.Name = newProduct.Name;
                    existingProduct.Price = newProduct.Price;
                    existingProduct.Quantity = newProduct.Quantity;
                    existingProduct.BoxSize = newProduct.BoxSize;
                    entity.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, existingProduct);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            using (ProductEntities entitiy = new ProductEntities())
            {
                var allUrlKeyValues = Request.GetQueryNameValuePairs();
                int pid = Convert.ToInt32(allUrlKeyValues.LastOrDefault(x => x.Key == "pid").Value);
                Product product = entitiy.Products.FirstOrDefault(x => x.ProductId == pid);
                if (product == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Product with Given Id does not exist!");

                entitiy.Products.Remove(product);
                entitiy.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
