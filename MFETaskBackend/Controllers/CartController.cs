using MFETaskBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace MFETaskBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public static List<Product> cartItems = new List<Product>();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetCart()
        {
            return Ok(cartItems);
        }

        [HttpPost]
        public ActionResult AddToCart(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product data is missing.");
            }

            cartItems.Add(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveFromCart(string id)
        {
            var productToRemove = cartItems.FirstOrDefault(p => p.Id == id);
            if (productToRemove == null)
            {
                return NotFound();
            }

            cartItems.Remove(productToRemove);
            return Ok();
        }
    }
}
