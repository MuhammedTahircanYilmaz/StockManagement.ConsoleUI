
// Bir ürünler listesi oluşturunuz.
// Bir Kategoriler listesi oluşturunuz.

// Bütün ürünleri listeleyen kodu yazınız.
// Bütün kategorileri listeleyen kodu yazınız.

// Kullanıcıdan kategori verilerini alıp listeye ekleyen,
// kural olarak daha önceden girilmiş bir id verisi varsa, ekran çıktısı olarak ekran çıktısı benzersiz olmalıdır :{id}
// Listeyi ekran çıktısı olarak veren kodu yazınız.

// Ürğnlerin fiyat toplamını gösteren kodu yazınız.

// Kullanıcıdan iki değer al. bu değerler min ve max olacak.
// Bu iki değer arasındaki stok verilerini getirsin 

// Ürünler listesinde bir isim parametresi alarak ürün isimlerinden uyuşanları listelesin.

// ProductDetail(string ProductName, double ProductPrice, int ProductStock, string CategoryName);
// kullanarak ürün detaylarını ekrana yazdırınız


using ConsoleUI.MyVersion;
using ConsoleUI.MyVersion.Model;
using ConsoleUI.MyVersion.Service;

ProductService productService = new ProductService();
CategoryServiceMV categoryService = new CategoryServiceMV();


List<Product> products = new List<Product>()
{
    new Product(1,1, "Beymen Takım ELbisesi", 15000, 175),
    new Product(2,1, "Prada Çanta", 75000, 10),
    new Product(3,2, "HK Vision Drone", 400000, 25),
    new Product(4,2, "Dyson Elektrikli Süpürge", 25000, 200),
    new Product(5,3, "Karaca Vazo", 500, 1000),
    new Product(6,3, "Kütahya Porselen Ayna", 1500, 200),
    new Product(7,4, "Adidas Futbol Topu", 5000,1254),
    new Product(8,4, "Delta Yoga Matı", 2000, 531)
};
List<Category> categories = new List<Category>()
{
    new Category(1,"Elbise", "Elbise Açıklaması"),
    new Category(2,"Elektronik", " Elektronik Açıklama"),
    new Category(3, "Dekorasyon", "Dekorasyon Açıklama"),
    new Category(4, "Spor Ekipmanı", "Spor Açıklama")
};

//GetALlProducts();
Console.WriteLine("\n***************************************\n");
//GetAllCategories();


//TotalProductPriceSum();
//GetAllProductsFilteredByPrice();
//GetAllProductNameContains();
//Delete();
productService.AddProduct(products);

categoryService.GetAllCategories();

void GetAllProducts()
{

    PrintSeparator("Bütün Ürünler");
    foreach (Product product in products)
    {
        Console.WriteLine(product);
    }

}

void PrintSeparator(string title)
{
    Console.WriteLine(title);
    Console.WriteLine("---------------------------------------");
}

void TotalProductPriceSum()
{
    double total = 0;
    PrintSeparator("Bütün Ürünlerin Fiyat Toplamı:");
    foreach (Product product in products)
    {
        total = total + product.Price;
    }
    Console.WriteLine($" Total: {total}");
}

void GetAllPriceRange(double min, double max)
{
    PrintSeparator($" {min} il {max} değer aralğındaki ürünler");
    foreach (Product product in products)
    {
        if (product.Price > min && product.Price < max)
        {
            Console.WriteLine(product);
        }
    }
}

void GetPriceRangeData(out double min, out double max)
{
    Console.WriteLine("Please input a minimum value:");
    min = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Please input a maximum value:");
    max = Convert.ToDouble(Console.ReadLine());
}

void GetAllProductsFilteredByPrice()
{
    double min;
    double max;
    GetPriceRangeData(out min, out max);
    GetAllPriceRange(min, max);
}

/*
void GetAllProductNameContains()
{
    string productName = GetProductName();
    foreach (Product product in products)
    {
        if (product.Name.Contains(productName, StringComparison.InvariantCultureIgnoreCase))
        {
            Console.WriteLine(product);
        }
    }
}
*/

string GetProductName()
{
    Console.WriteLine("Please enter a product name");
    string productName = Console.ReadLine();
    while (string.IsNullOrEmpty(productName) || string.IsNullOrWhiteSpace(productName))
    {
        Console.WriteLine("The product name cannot be empty or null. Please enter valid name,");
        productName = Console.ReadLine();
    }
    return productName;
}

void Delete()
{
    PrintSeparator("deletion");
    Console.WriteLine("Please input product id");
    int id = Convert.ToInt32(Console.ReadLine());

    bool isPresent = false;

    foreach (Product product in products)
    {
        if (product.Id == id)
        {
            products.Remove(product);
            isPresent = true;
            break;
        }
    }

    if (!isPresent)
    {
        Console.WriteLine($"The product with the id ({id}) does not exist.");
        Console.WriteLine((isPresent));
        return;
    }
    else
    {
        Console.WriteLine($"The item with the id ({id}) has been deleted.");
    }

    foreach (Product item in products)
    {
        Console.WriteLine(item);
    }


}

// kullanıcıdan ürün isteyip kaç adaet satın almak istediklerini sor. 
// stokta o kadar ürün varsa kullanıcıya toplam ücretini ver
// satılan ürünü stoktan düş
// stok sayısı 0 a düşerse stoktan ürünü sil

// kullanıcı stok sayısından fazla ürün almak isterse kullanıcıyı ürün miktarı konusunda uyar

void PurchaseOfProduct()
{
    ProductService productManager = new ProductService();
    GetAllProducts();
    Console.WriteLine("Please input the product Id you wish to purchase");
    int id = Convert.ToInt32((Console.ReadLine()));

    Console.WriteLine("please input the amount of products you wish to purchase");
    int stock = Convert.ToInt32((Console.ReadLine()));

    Product product = new Product(0,0, string.Empty, 0, 0);
    foreach (Product p in products)
    {
        if (p.Id == id)
        {
            product = p;
            break;
        }
    }
    if (stock > product.Stock)
    {
        Console.WriteLine($"you can only buy a maximum of: {product.Stock} of the product.");
        return;
    }
    int newStock = product.Stock - stock;
    Product updatedProduct = new Product(
        product.Id, product.CategoryId, product.Name, product.Price, newStock
        );
    if (updatedProduct.Stock == 0)
    {
        products.Remove(product);
        Console.WriteLine("You've purchased all available stock");
        GetAllProducts();
        return;
    }

    string productName = updatedProduct.Name;
    int amount = stock;
    double totalPrice = stock * updatedProduct.Price;

    Console.WriteLine($"The name of the Product : {productName}");
    Console.WriteLine($"The amount bought : {stock}");
    Console.WriteLine($"The total Cost : {totalPrice}");

    int productIndex = products.IndexOf(product);
    products.Remove(product);
    products.Insert(productIndex, updatedProduct);

    GetAllProducts();
}
