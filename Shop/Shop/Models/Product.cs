using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }

        public string Categorie { get; set; }
        public string Description { get; set; }
        public double price { get; set; }
        public bool IsSelledPrice { get; set; } = false;

    }
}
