using Newtonsoft.Json;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Shop.Models
{
    public class ApiLoginModel : IDummyLoginRegistrationService
    {
        static string APP_PATH = "";
        public void addProductTocart(Product product, string token)
        {
            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Id", $"{product.id}"),
                   
                };
            var content = new FormUrlEncodedContent(pairs);
            using (var client = CreateClient(token))
            {
                client.PostAsync(APP_PATH + "/api/Cart", content);
               
            }
        }

        public void BuyProductsIncart(string token)
        {
            using (var httpclient = CreateClient(token))
            {

                httpclient.PostAsync(APP_PATH + "/api/Cart",null);
              
            }
        }

        public List<Product> GetProductsFromCart(string token)
        {
            throw new NotImplementedException();
        }

        public string GetToken(string email, string password)
        {
            Dictionary<string, string> tokenDictionary = GetTokenDictionary(email, password);
            if (tokenDictionary.ContainsKey("access_token"))
            {
                return tokenDictionary["access_token"];

            }
            else return "token";
        }
        public bool LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Registration(string email, string name, string password)
        {

            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Email", email),
                    new KeyValuePair<string, string>("Password", password),
                    new KeyValuePair<string, string> ("Name", name)
                };
           
            var content = new FormUrlEncodedContent(pairs);
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(APP_PATH + "/api/Account/Register", content);

            }
        }


        static HttpClient CreateClient(string accessToken = "")
        {
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
            return client;
        }
        static Dictionary<string, string> GetTokenDictionary(string userName, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string> ("Password", password)
                };
            var content = new FormUrlEncodedContent(pairs);

            using (var client = new HttpClient())
            {
                var response =
                    client.PostAsync(APP_PATH + "/Token", content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                // Десериализация полученного JSON-объекта
                Dictionary<string, string> tokenDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                return tokenDictionary;
            }
        }
    }
}
