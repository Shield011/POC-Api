using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POCApiFinal.Models;
using POCApiFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCApiFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
           _cartService = cartService;
          
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCartItems()
        {
            var items = await _cartService.GetCartItems();
            return items;

        }

        [HttpPost]
        public async Task<IActionResult> PostItemCart(Product product)
        {
            var res = await _cartService.AddCartItem(product);
            return Ok() ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItems(int id, Cart cart)
        {
            await _cartService.UpdateItems(id, cart);
            return Ok();
        }

        [HttpPost]
        [Route("counter")]
        public async Task<IActionResult> CountCounter(Counter counter)
        {
            await _cartService.Counter(counter);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            await _cartService.DeleteItem(id);
            return Ok();
        }

        

    }
}
;