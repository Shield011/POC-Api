using POCApiFinal.Models;
using POCApiFinal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCApiFinal.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryBase _repositoryBase;
        private readonly ICartService _cartService;
        public ProductService(IRepositoryBase repositoryBase, ICartService cartService)
        {

            _repositoryBase = repositoryBase;
            _cartService = cartService;
        }

        public async Task<List<Product>> GetProductList()
        {
            var prodList = await _repositoryBase.GetProductList();
            return prodList;
        }
        public async Task<Product> AddProduct(AddProduct addProduct)
        {
            Product product = new Product();
            product.ProductName = addProduct.name;
            product.Price = addProduct.price;
            product.ProductCount = 0;
            product.InCart = "false";

            var prod = await _repositoryBase.AddProduct(product);
            return prod;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var prod = await _repositoryBase.UpdateProductItem(id, product);
            return prod;
        }


        public async Task DeleteProduct(int id)
        {
            var item = await _repositoryBase.GetCartListByID(id);

            if(item != null)
            {
                await _cartService.DeleteItem(item.ProductId);
            }


            await _repositoryBase.DeleteProduct(id);

        }
        

    }
}
