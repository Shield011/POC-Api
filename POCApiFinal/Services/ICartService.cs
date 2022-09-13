using POCApiFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCApiFinal.Services
{
    public interface ICartService
    {
        Task<List<Cart>> GetCartItems();
        Task<Cart> GetCartItemById(int id);
        Task<Cart> AddCartItem(Product product);

        Task DeleteItem(int id);
        Task<Cart> UpdateItems(int id, Cart cart);
        Task Counter(Counter counter);

    }
}
