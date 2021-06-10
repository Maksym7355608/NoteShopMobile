using Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services
{
    public interface IDummyLoginRegistrationService
    {
        bool LoginUser(string email, string password);
        void Registration(string email, string name, string password);
        string GetToken(string email, string password);
         void BuyProductsIncart(string token);
         void addProductTocart(Product product, string token);
        List<Product> GetProductsFromCart(string token);
    }
}
