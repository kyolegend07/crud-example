using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiTutorial.Models;
namespace ApiTutorial.Controllers
{
    public class ProductController : ApiController
    {
        private ProductContext db = new ProductContext();
        [HttpGet()]
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            List<Product> list = new List<Product>();
            list = db.Products.ToList();
            ret = Ok(list);
            return ret;
        }
        private List<Product> CreateMockData()
        {
            List<Product> ret = new List<Product>();
            ret.Add(new Product()
            {
                ProductId = 1,
                ProductName = "Extending Bootstrap with CSS, JavaScript and jQuery", IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/1SNzc0i"
            });

            ret.Add(new Product()
            {
                ProductId = 2,
                ProductName = "Build your own Bootstrap Business Application Template in MVC", IntroductionDate = Convert.ToDateTime("1/29/2015"),
                Url = "http://bit.ly/1I8ZqZg"
            });

            ret.Add(new Product()
            {
                ProductId = 3,
                ProductName = "Building Mobile Web Sites Using Web Forms, Bootstrap, and HTML5", IntroductionDate = Convert.ToDateTime("8/28/2014"),
                Url = "http://bit.ly/1J2dcrj"
            });

            return ret;
        }

        [HttpGet()]
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult ret;
            List<Product> list = new List<Product>();
            Product prod = new Product();

            prod = db.Products.Where(x => x.ProductId == id).First();
            if (prod == null)
            {
                ret = NotFound();
            }
            else {
                ret = Ok(prod);
            }

            return ret;
        }
    }
}
