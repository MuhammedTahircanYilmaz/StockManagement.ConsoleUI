using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.MyVersion.Data;
using ConsoleUI.MyVersion.Model;
using ConsoleUI.MyVersion.Model.Dto;

public class ProductData
{

    private List<Product> products = new List<Product>()
    {
    new Product(1,1,"Beymen Takım Elbise",15000,250),
    new Product(2,1,"Prada Çanta",60000,10),
    new Product(3,2,"Hk Vision Drone",400000,25),
    new Product(4,2,"Dyson Süpürge",32000,200),
    new Product(5,3,"Karaca Vazo",500,1000),
    new Product(6,3,"Kütahya Porselen Ayna",1500,200),
    new Product(7,4,"Adidas Futbol Topu",5000,1254),
    new Product(8,4,"Delta Yoga Matı",2000,531)
    };


    public Product Add(Product product)
    {
        products.Add(product);
        return product;
    }

    public double TotalProductPriceSum()
    {
        double total = products.Sum(x => x.Price);
        return total;
    }

    public List<Product> GetAllPriceRange(double min, double max)
    {
        var filteredProducts = products.Where(x => x.Price <= max && x.Price >= min).ToList();
        return filteredProducts;
        // Where(lambda[Dönüş tipi : bool]) : Verilerin filtrelenmesi için kullanılır.
    }

    public List<Product> GetAllProductNameContains(string text)
    {
        //3. Yöntem (  FindAll(lambda[Dönüş tipi : bool]) : Where.ToList den farkı işin sonunda sadece Liste döndürür. )
        var filteredProducts = products.FindAll(x => x.Name.Contains(text, StringComparison.InvariantCultureIgnoreCase));

        return filteredProducts;
    }

    public Product? GetById(int id)
    {
        Product? product = products.SingleOrDefault(x => x.Id == id);

        return product;
    }

    public Product Delete(int id)
    {
        Product? product = GetById(id);

        if (product is not null)
        {
            products.Remove(product);
        }

        return product;
    }

    public List<Product> GetAll()
    {
        return products;
    }

    public List<Product> GetAllProductsByStockRange(int min, int max)
    {
        List<Product> filtered = products.FindAll(x => x.Stock <= max && x.Stock >= min);
        return filtered;
    }

    public List<Product> GetAllProductsOrderedByAscendingName()
    {
        List<Product> orderPy = products.OrderBy(x => x.Name).ToList();
        return orderPy;
    }

    public List<Product> GetAllProductsOrderedByDescendingName()
    {
        List<Product> orderBy = products.OrderByDescending(x => x.Name).ToList();
        return orderBy;
    }

    public Product GetExpensiveProduct()
    {
        Product? product = products.OrderBy(x => x.Price).LastOrDefault();
        return product;
    }
    public Product GetCheapProduct()
    {
        Product? product = products.OrderBy(x => x.Price).FirstOrDefault();
        return product;
    }

    public Product GetTheCheapestProductWhereProductHasTheLetterAInTheName()
    {
        List<Product> productsFilteredByA = products.FindAll(x => x.Name.Contains("a", StringComparison.InvariantCultureIgnoreCase));

        Product? product = productsFilteredByA.OrderBy(x => x.Price).FirstOrDefault();
        return product;
    }

    public List<ProductDetailDto> GetProductDetails(List<Category> categories)
    {
        var result = from p in products
                     join c in categories
                     on p.CategoryId equals c.Id


                     select new ProductDetailDto(
                         Id: p.Id,
                         CategoryName: c.Name,
                         Name: p.Name,
                         Price: p.Price,
                         Stock: p.Stock
                         );

        return result.ToList();
    }

    public List<ProductDetailDto> GetProductDetailsV2(List<Category> categories)
    {
        List<ProductDetailDto> details =
            products.Join(categories,
            p => p.CategoryId,
            c => c.Id,
            (pr, ca) => new ProductDetailDto(
                Id: pr.Id,
                CategoryName: ca.Name,
                Name: pr.Name,
                Price: pr.Price,
                Stock: pr.Stock
                )
            ).ToList();
        return details;
    }

    public ProductDetailDto? GetDetailById(int id, List<Category> categories)
    {
        var result = from p in products
                     where p.Id == id
                     join c in categories
                     on p.CategoryId equals c.Id

                     select new ProductDetailDto(
                         Id: p.Id,
                         CategoryName: c.Name,
                         Name: p.Name,
                         Price: p.Price,
                         Stock: p.Stock
                         );

        return result.FirstOrDefault();
    }
}

