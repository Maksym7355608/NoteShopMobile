using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.ViewModels
{
    public class ProdcutViewModel
    {
        public IProductService service { get; set; }
        public ProdcutViewModel()
        {
            service = new DummyProduct();
        }
    }
}
