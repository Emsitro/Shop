using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using shop.models;

namespace shop.Controllers
{
    [ApiController]
    [Route("/Seller")]
    public class SellerController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get ()
        {
            maindbcontext db = new maindbcontext();
            List<seller> sellers = db.sellers.ToList();
            string jsonSeller = JsonSerializer.Serialize(sellers);
            return Ok(jsonSeller);
        }
        [HttpPost]
        public ActionResult Add (seller seller)
        {
            maindbcontext db = new maindbcontext ();
            db.sellers.Add(seller);
            db.SaveChanges();
            seller addseller = db.sellers.FirstOrDefault(u=>u.Name== seller.Name);
            string jsonSeller = JsonSerializer.Serialize(seller);
            return Ok("seller successfully added");
        }
        [HttpDelete]
        public ActionResult Delete (seller seller) {
            maindbcontext db = new maindbcontext();
            seller delone = db.sellers.FirstOrDefault(u => u.Id == seller.Id);
            db.sellers.Remove(delone);
            db.SaveChanges();
            string jsonSeller = JsonSerializer.Serialize(seller);
            return Ok("seller successfully deleted"); 
        }
        [HttpPatch]
        public ActionResult Replace (seller seller) {
        maindbcontext db = new maindbcontext ();
            seller delone = db.sellers.FirstOrDefault(u => u.Name == seller.Name);
            db.sellers.Remove(delone);
            db.SaveChanges();
            seller addseller = db.sellers.FirstOrDefault(u => u.Name == seller.Name);
            db.sellers.Add(seller);
            db.SaveChanges();
            string jsonSeller = JsonSerializer.Serialize(seller);
            return Ok("seller successfully replace");
        }
    }
}
