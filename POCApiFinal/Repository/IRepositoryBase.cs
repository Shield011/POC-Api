using POCApiFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCApiFinal.Repository
{
    public interface IRepositoryBase
    {
        Task<List<Cart>> GetCartList();
        Task<Cart> GetCartListByID(int id);
        Task<Cart> AddItem(Cart cart);

        Task<Cart> UpdateCartItem(int id, Cart cart);
        Task DeleteItem(int id);

        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductList();

        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProductItem(int id, Product product);
        Task DeleteProduct(int id);
        bool ItemExists(int id);

    }
}
