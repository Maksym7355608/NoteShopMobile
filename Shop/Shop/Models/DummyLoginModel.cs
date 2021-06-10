using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class DummyLoginModel : IDummyLoginRegistrationService
    {
        public static List<Login> logins = new List<Login> { new Login { Email = "admin@mail.ru", Password = "admin1111", name = "admin", token = "admin@mail.ruadmin1111admin" , products= new List<Product>() { new Product() { id=1} } } };

     

        public string GetToken(string email, string password)
        {
            return logins.Where(r => r.Email == email & r.Password == password).FirstOrDefault().token;
        }

       

        public bool LoginUser(string email, string password)
        {
            return logins.Any(r => r.Email == email & r.Password ==password);
        }

       

        public void Registration(string email, string name, string password)
        {
            logins.Add(new Login { Email = email, name = name, Password = password, token = email.ToString() + password.ToString() + name.ToString() });
        }

        public void BuyProductsIncart(string token)
        {
            logins.Where(r => r.token == token).FirstOrDefault().products.Clear();
        }

        public void addProductTocart(Product product, string token)
        {
            logins.Where(r => r.token == token).FirstOrDefault().products.Add(new Product { name = product.name, price = product.price, id = product.id });
        }

        public List<Product> GetProductsFromCart(string token)
        {
            return logins.Where(r => r.token == token).FirstOrDefault().products.ToList();
        }
    }
}
