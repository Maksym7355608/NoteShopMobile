using Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services
{
    public interface IProductService
    {

        List<Product> GetAllProducts();
        List<Product> GetAllProductsWithDiscounts();
        Product GetProductById(int id);
      

    }
}
