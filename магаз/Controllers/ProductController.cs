using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using shop.models;

namespace shop.Controllers
{
    [ApiController]
    [Route("/product")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get ()
        {
            maindbcontext db = new maindbcontext();
            List<product>products = db.products.ToList();
            string jsonProduct = JsonSerializer.Serialize(products);
            return Ok(jsonProduct);
        }
        [HttpPost]
        public ActionResult Add (product product)
        {
            maindbcontext db = new maindbcontext ();
            db.products.Add(product);
            db.SaveChanges();
            product addproduct = db.products.FirstOrDefault(u=>u.Name==product.Name);
            string jsonProduct = JsonSerializer.Serialize(product);
            return Ok("product successfully added");
        }
        [HttpDelete]
        public ActionResult Delete (product product) {
            maindbcontext db = new maindbcontext();
            product delone = db.products.FirstOrDefault(u => u.Id == product.Id);
            db.products.Remove(delone);
            db.SaveChanges();
            string jsonProduct = JsonSerializer.Serialize(product);
            return Ok("product successfully deleted"); 
        }
        [HttpPatch]
        public ActionResult Replace (product product) {
        maindbcontext db = new maindbcontext ();
            product delone = db.products.FirstOrDefault(u => u.Name == product.Name);
            db.products.Remove(delone);
            db.SaveChanges();
            product addproduct = db.products.FirstOrDefault(u => u.Name == product.Name);
            db.products.Add(product);
            db.SaveChanges();
            string jsonProduct = JsonSerializer.Serialize(product);
            return Ok("product successfully replace");
        }
    }
}
