using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Models
{
    public class DummyProduct : IProductService
    {
        static List<Product> products = new List<Product>()
        {
            new Product() { Categorie="Pencils" , name="HEXAGON", Description="Made in USA, Certified non-toxic and conforms to ASTM D4236, Wood case pencils with special soft lead, Latex-free synthetic erasers" , id=1, price=144, IsSelledPrice=false  },
            new Product() { Categorie="Pencils" , name="HEXAGON2", Description="Made in USA, Certified non-toxic and conforms to ASTM D4236, Wood case pencils with special soft lead, Latex-free synthetic erasers" , id=2, price=144.1, IsSelledPrice=true  },
            new Product() { Categorie="Pencils" , name="HEXAGON3", Description="Made in USA, Certified non-toxic and conforms to ASTM D4236, Wood case pencils with special soft lead, Latex-free synthetic erasers" , id=3, price=144.1, IsSelledPrice=false  },
            new Product() { Categorie="Pencils" , name="HEXAGON4", Description="Made in USA, Certified non-toxic and conforms to ASTM D4236, Wood case pencils with special soft lead, Latex-free synthetic erasers" , id=5, price=144.5, IsSelledPrice=true  },
            new Product() { Categorie="Pencils" , name="HEXAGON5", Description="Made in China, Certified non-toxic and conforms to ASTM D4236, Wood case pencils with special soft lead, Latex-free synthetic erasers" , id=7, price=144.5, IsSelledPrice=false  },
            new Product() { Categorie="Notebooks" , name="Doodle Unicorn", Description="Cover structure and feel: The front cover has a silver foil and spot Uv text Adds-ons: This notebook is styled with a theme-based dangler that can also be used as a bookmark to make sure that you can pick up where you left off Easy to write and tear: It's a hard bound journal with stop-wiro binding and round edges, making it easy to open flat and write comfortably as well as tearing pages neatly Pages and ruling: This dateless journal comes with 160 ruled a5 pages for you to fill with your aspirations Ideal for: This is the made for the woman who loves putting her feelings on paper, it is the best gift for an anniversary, a birthday, women’s day Country of Origin: India" , id=4, price=21, IsSelledPrice=false  },
            new Product() { Categorie="Notebooks" , name="Doodle Unicorn2", Description="Cover structure and feel: The front cover has a silver foil and spot Uv text Adds-ons: This notebook is styled with a theme-based dangler that can also be used as a bookmark to make sure that you can pick up where you left off Easy to write and tear: It's a hard bound journal with stop-wiro binding and round edges, making it easy to open flat and write comfortably as well as tearing pages neatly Pages and ruling: This dateless journal comes with 160 ruled a5 pages for you to fill with your aspirations Ideal for: This is the made for the woman who loves putting her feelings on paper, it is the best gift for an anniversary, a birthday, women’s day Country of Origin: India" , id=9, price=21, IsSelledPrice=false  },
            new Product() { Categorie="Notebooks" , name="Doodle Unicorn3", Description="Cover structure and feel: The front cover has a silver foil and spot Uv text Adds-ons: This notebook is styled with a theme-based dangler that can also be used as a bookmark to make sure that you can pick up where you left off Easy to write and tear: It's a hard bound journal with stop-wiro binding and round edges, making it easy to open flat and write comfortably as well as tearing pages neatly Pages and ruling: This dateless journal comes with 160 ruled a5 pages for you to fill with your aspirations Ideal for: This is the made for the woman who loves putting her feelings on paper, it is the best gift for an anniversary, a birthday, women’s day Country of Origin: India" , id=10, price=21, IsSelledPrice=true  },
            new Product() { Categorie="Notebooks" , name="Doodle Unicorn4", Description="Cover structure and feel: The front cover has a silver foil and spot Uv text Adds-ons: This notebook is styled with a theme-based dangler that can also be used as a bookmark to make sure that you can pick up where you left off Easy to write and tear: It's a hard bound journal with stop-wiro binding and round edges, making it easy to open flat and write comfortably as well as tearing pages neatly Pages and ruling: This dateless journal comes with 160 ruled a5 pages for you to fill with your aspirations Ideal for: This is the made for the woman who loves putting her feelings on paper, it is the best gift for an anniversary, a birthday, women’s day Country of Origin: India" , id=11, price=21, IsSelledPrice=false  },
            new Product() { Categorie="Notebooks" , name="Doodle Unicorn5", Description="Cover structure and feel: The front cover has a silver foil and spot Uv text Adds-ons: This notebook is styled with a theme-based dangler that can also be used as a bookmark to make sure that you can pick up where you left off Easy to write and tear: It's a hard bound journal with stop-wiro binding and round edges, making it easy to open flat and write comfortably as well as tearing pages neatly Pages and ruling: This dateless journal comes with 160 ruled a5 pages for you to fill with your aspirations Ideal for: This is the made for the woman who loves putting her feelings on paper, it is the best gift for an anniversary, a birthday, women’s day Country of Origin: India" , id=12, price=21, IsSelledPrice=false  },
            new Product() { Categorie="Elastics" , name="RHINO A5", Description="SKU: SDRR5-6 UPC: 5010642421120 Shipping: Calculated at Checkout Size: A5 Ruling: DY Page Count: 40 Pages" , id=6, price=12.4, IsSelledPrice=false  },
            new Product() { Categorie="Elastics" , name="RHINO A5", Description="SKU: SDRR5-6 UPC: 5010642421120 Shipping: Calculated at Checkout Size: A5 Ruling: DY Page Count: 40 Pages" , id=8, price=12.4, IsSelledPrice=true  },
            new Product() { Categorie="Elastics" , name="RHINO A5", Description="SKU: SDRR5-6 UPC: 5010642421120 Shipping: Calculated at Checkout Size: A5 Ruling: DY Page Count: 40 Pages" , id=13, price=12.4, IsSelledPrice=false  },
            new Product() { Categorie="Elastics" , name="RHINO A5", Description="SKU: SDRR5-6 UPC: 5010642421120 Shipping: Calculated at Checkout Size: A5 Ruling: DY Page Count: 40 Pages" , id=14, price=12.4, IsSelledPrice=true  },
            new Product() { Categorie="Elastics" , name="RHINO A5", Description="SKU: SDRR5-6 UPC: 5010642421120 Shipping: Calculated at Checkout Size: A5 Ruling: DY Page Count: 40 Pages" , id=15, price=12.4, IsSelledPrice=false  },
        };
       

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public List<Product> GetAllProductsWithDiscounts()
        {
            return products.Where(r => r.IsSelledPrice = true).ToList();
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(r => r.id == id);
        }
    }
}
