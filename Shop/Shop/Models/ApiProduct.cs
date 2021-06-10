using Shop.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft;
using System.Text.Json;

namespace Shop.Models
{
    public class ApiProduct : IProductService
    {
        static string APP_PATH = "";

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

        public List<Product> GetAllProducts()
        {
            using (var httpclient = new HttpClient())
            {

                string response =  httpclient.GetStringAsync(APP_PATH + "/api/Products").Result;
               
                return JsonSerializer.Deserialize<List<Product>>(response);
            }
        }
        public List<Product> GetAllProductsWithDiscounts()
        {
            using (var httpclient = new HttpClient())
            {

                string response = httpclient.GetStringAsync(APP_PATH + "/api/Products/Discount").Result;

                return JsonSerializer.Deserialize<List<Product>>(response);
            }
        }

        public Product GetProductById(int id)
        {
            using (var httpclient = new HttpClient())
            {

                string response = httpclient.GetStringAsync(APP_PATH + "/api/Products").Result;

                return JsonSerializer.Deserialize<Product>(response);
            }
        }
    }
}
