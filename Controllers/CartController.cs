using AllTheBeansApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AllTheBeansApp.Controllers
{
    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository;

        public CartController()
        {
            _cartRepository = new CartRepository();
        }

        public IActionResult Index()
        {
            var cartItems = _cartRepository.GetCartItems();
            return View(cartItems);
        }
        // Add to cart
        [HttpPost]
        public IActionResult AddToCart([FromBody] CartItem item)
        {
            _cartRepository.AddToCart(item);
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateCartItem([FromBody] CartItem item)
        {
            _cartRepository.UpdateCartItem(item);
            return Ok();
        }


        // Remove From Cart
        [HttpPost]
        public IActionResult RemoveFromCart([FromBody] CartItem item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                return BadRequest("Item name cannot be null or empty.");
            }

            _cartRepository.RemoveFromCart(item.Name);
            return Ok();
        }
    }
}
