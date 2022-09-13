using Microsoft.EntityFrameworkCore;
using POCApiFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCApiFinal.Repository
{
    public class RepositoryBase: IRepositoryBase
    {
        private readonly ProductContext _context;
        public RepositoryBase(ProductContext context)
        {
            _context = context;
                
        }

        public async Task<List<Cart>> GetCartList()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> GetCartListByID(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(e => e.ProductId == id);
        }

        public async Task<Cart> AddItem(Cart cart)
        {
            var res = await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Cart> UpdateCartItem(int id, Cart cart)

        {
            var res = await _context.Carts.FirstOrDefaultAsync(e => e.ProductId == id);

            if(res != null)
            {
                res.ProductName = cart.ProductName;
                res.ProductCount = cart.ProductCount;
                res.ProductId = cart.ProductId;
                res.Price = cart.Price;

                await _context.SaveChangesAsync();

                return res;
            }

            return null;
        }

        public async Task DeleteItem(int id)
        {
            var res = await _context.Carts.FirstOrDefaultAsync(e => e.ProductId == id);

            if(res != null)
            {
                _context.Carts.Remove(res);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(e => e.ProductId == id);
        }

        public async Task<List<Product>> GetProductList()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            var res = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return res.Entity;

        }

        public async Task<Product> UpdateProductItem(int id, Product product)

        {
            var res = await _context.Products.FirstOrDefaultAsync(e => e.ProductId == id);

            if (res != null)
            {
                res.ProductName = product.ProductName;
                res.ProductCount = product.ProductCount;
                res.ProductId = product.ProductId;
                res.Price = product.Price;
                res.InCart = product.InCart;

                await _context.SaveChangesAsync();

                return res;
            }

            return null;
        }

        public async Task DeleteProduct(int id)
        {
            var res = await _context.Products.FirstOrDefaultAsync(e => e.ProductId == id);

            if (res != null)
            {
                _context.Products.Remove(res);
                await _context.SaveChangesAsync();
            }

        }

        public bool ItemExists(int id)
        {
            return _context.Carts.Any(e => e.ProductId == id);
        }




    }
}
