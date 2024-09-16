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


using StockManagement.ConsoleUI;
using StockManagement.ConsoleUI.model;
using StockManagement.ConsoleUI.service;
List<Product> products = new List<Product>()
{
    new Product(1, "Beymen Takım ELbisesi", 15000, 175),
    new Product(2, "Prada Çanta", 75000, 10),
    new Product(3, "HK Vision Drone", 400000, 25),
    new Product(4, "Dyson Elektrikli Süpürge", 25000, 200),
    new Product(5, "Karaca Vazo", 500, 1000),
    new Product(6, "Kütahya Porselen Ayna", 1500, 200),
    new Product(7, "Adidas Futbol Topu", 5000,1254),
    new Product(8, "Delta Yoga Matı", 2000, 531)
};
List<Category> categories = new List<Category>()
{
    new Category(1,"Elbise", "Elbise Açıklaması"),
    new Category(2,"Elektronik", " Elektronik Açıklama"),
    new Category(3, "Dekorasyon", "Dekorasyon Açıklama"),
    new Category(4, "Spor Ekipmanı", "Spor Açıklama")
};

GetALlProducts();
Console.WriteLine("\n***************************************\n");
GetAllCategories();

AddProductAndGetAll(products);

void GetAllCategories()
{

    PrintSeparator("Bütün Kategoriler:");
    foreach (Category category in categories)
    {
        Console.WriteLine(category);
    }

}

void GetALlProducts()
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

void AddProductAndGetAll(List<Product> products)
{
    ProductManager productManager = new ProductManager(products);
    
    PrintSeparator("Ürün ekle ve listele: ");

    int id = productManager.GetProductId(products);

    string name = productManager.GetProductName();

    double price = productManager.GetProductPrice(); 

    int stock = productManager.GetProductStock();

    Product createdProduct = new Product(id, name, price, stock);
    
    products.Add(createdProduct);

    foreach(Product product in products)
    {
        Console.WriteLine(product);
    }
}
