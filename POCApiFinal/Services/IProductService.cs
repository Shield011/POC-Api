using POCApiFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCApiFinal.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductList();

        Task<Product> UpdateProduct(int id, Product product);
        Task<Product> AddProduct(AddProduct addProduct);

        Task DeleteProduct(int id);

    }
}
