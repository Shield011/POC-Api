using POCApiFinal.Models;
using POCApiFinal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCApiFinal.Services
{
   
    public class CartService : ICartService
    {
        
        private readonly IRepositoryBase _repositoryBase;
        public CartService(IRepositoryBase repositoryBase)
        {

            _repositoryBase = repositoryBase;
        }

        public async Task<List<Cart>> GetCartItems()
        {
            var cartItems = await _repositoryBase.GetCartList();
            return cartItems;
        }

        public async Task<Cart> GetCartItemById(int id)
        {
            var item = await _repositoryBase.GetCartListByID(id);
            return item;
        }

        public async Task<Cart> AddCartItem(Product product)
        {
            var prod = await _repositoryBase.GetProductById(product.ProductId);
            if(product != null)
            {
                product.ProductCount += 1;
                product.InCart = "true";
            }
            await _repositoryBase.UpdateProductItem(product.ProductId, product);

            var item = await _repositoryBase.GetCartListByID(product.ProductId);
            if(item != null)
            {

                item.ProductCount = product.ProductCount;
                await _repositoryBase.UpdateCartItem(product.ProductId, item);

            }
            else
            {
                Cart newItem = new Cart();
                newItem.ProductName = prod.ProductName;
                newItem.ProductId = prod.ProductId;
                newItem.ProductCount = prod.ProductCount;
                newItem.Price = prod.Price;
                await _repositoryBase.AddItem(newItem);
            }


            return item;
        }

        public async Task<Cart> UpdateItems(int id, Cart cart)
        {
            var updatedItem = await _repositoryBase.UpdateCartItem(id, cart);
            return updatedItem;

        }

        public async Task DeleteItem(int id)
        {
            var product = await _repositoryBase.GetProductById(id);
            product.ProductCount = 0;
            product.InCart = "false";
            await _repositoryBase.UpdateProductItem(product.ProductId, product);
            await _repositoryBase.DeleteItem(id);
            

        }

        public async Task Counter(Counter counter)
        {
            var product = await _repositoryBase.GetProductById(counter.id);

            var item = await _repositoryBase.GetCartListByID(counter.id);
            if(item != null)
            {
                if(counter.type == "increase")
                {
                    product.ProductCount += 1;
                    await _repositoryBase.UpdateProductItem(product.ProductId, product);

                }
                else
                {
                    if(product.ProductCount == 1)
                    {
                        await DeleteItem(product.ProductId);
                        
                    }

                    else
                    {
                        product.ProductCount -= 1;
                        await _repositoryBase.UpdateProductItem(product.ProductId, product);


                    }
                }
                

            }

            item.ProductCount = product.ProductCount;
            await UpdateItems(item.ProductId, item);
        }

           
            

    }
}
