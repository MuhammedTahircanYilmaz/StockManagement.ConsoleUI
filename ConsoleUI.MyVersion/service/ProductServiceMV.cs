using ConsoleUI.MyVersion.Model;
using ConsoleUI.MyVersion.Data;
using ConsoleUI.MyVersion.Service;
using System;
using System.Threading.Channels;

namespace ConsoleUI.MyVersion.Service;

public class ProductService
{
    CategoryServiceMV categoryService = new CategoryServiceMV();
    ProductData productData = new ProductData();
    Product Product;
    List<Product> Products;

    public ProductService()
    {
    }

    public ProductService(List<Product> products)
    {
        Products = products;
    }

    public void AddProduct(List<Product> products)
    {
        Product createdProduct = GetProductInput(products);
        productData.Add(createdProduct);
    }

    public int GetProductId(List<Product> products)
    {
        bool isUnique = false;

        Console.WriteLine("Please input Product Id:");

        string answerToCheck = GetAnswer(Console.ReadLine()); //the given answer is checked to see if it is empty, null or whitespace

        bool isInt = CheckNumerical(answerToCheck);
        if (!isInt)
        {
            Console.WriteLine("You have input an invalid type of data. You must enter a number");
        }
        else
        {
            if (CheckValidId(answerToCheck))
            {
                isUnique = true;
            }
        }

        while (isUnique == false) //we ask for a unique id. If the id is not unique, we continue asking till we get a unique one
        {
            Console.WriteLine($"Product Id must be unique and higher than (0). The Id you are trying to input is \"{answerToCheck}\"");
            Console.WriteLine("Please input valid Product Id:");
            answerToCheck = GetAnswer(Console.ReadLine()); // we recheck every single time for invalid answers
            isInt = CheckNumerical(answerToCheck);
            if (!isInt)
            {
                Console.WriteLine("You have input an invalid type of data. You must enter a number");
            }
            else
            {
                if (CheckValidId(answerToCheck))
                {
                    isUnique = true;
                }
            }
        }
        int finalId = Convert.ToInt32(answerToCheck);
        return finalId;
    }

    public int GetCategoryId(List<Category> categories)
    {
        List<Category> categoryList = categoryService.GetAllCategories();
        int id = 1;
        Console.WriteLine("Categories are:");
        categoryList.ForEach(x => { Console.WriteLine($"{id}-" + x.Name); id++; });

        Console.WriteLine("Please input Category Id:");

        string answerToCheck = GetAnswer(Console.ReadLine()); //the given answer is checked to see if it is empty, null or whitespace
        bool isInt = CheckNumerical(answerToCheck);

        int categoryId = Convert.ToInt32(Console.ReadLine());
        return categoryId;
    }

    public bool CheckValidId(string idToBeChecked)
    {

        int id = Convert.ToInt32(idToBeChecked);

        if (id <= 0)
        {
            return false;
        }


        foreach (Product product in Products) // We check to see if a product with the given Id is already present in the database
        {
            if (product.Id == id)
            {
                return false;
            }
        }

        return true;
    }

    bool CheckNumerical(string id)
    {
        string acceptedAnswers = "0123456789";

        foreach (char s in id)
        {
            if (!acceptedAnswers.Contains(s))
            {
                Console.WriteLine("This field has to contain only numbers");
                return false;
            }
        }
        return true;
    }
    public string GetProductName()
    {
        Console.WriteLine("Please input a Product Name: ");
        string productName = GetAnswer(Console.ReadLine());
        return productName;
    }

    public double GetProductPrice()
    {
        Console.WriteLine("Please input the Product Price:");
        string answerToCheck = GetAnswer(Console.ReadLine());
        bool isDigit = CheckNumerical(answerToCheck);
        bool isValid = false;
        if (!isDigit)
        {
            Console.WriteLine("You have input an invalid type of data. You must enter a number");
        }
        else
        {
            if (CheckValidPrice(answerToCheck))
            {
                isValid = true;
            }
        }

        while (isValid == false)
        {
            Console.WriteLine("The Product Price cannot be lower than or equal to zero (0). Please input a valid price:");
            answerToCheck = GetAnswer(Console.ReadLine());
            isDigit = CheckNumerical(answerToCheck);
            if (!isDigit)
            {
                Console.WriteLine("You have input an invalid type of data. You must enter a number");
            }
            else
            {
                if (CheckValidPrice(answerToCheck))
                {
                    isValid = true;
                }
            }
        }

        double price = Convert.ToDouble(answerToCheck);
        return price;
    }

    public bool CheckValidPrice(string answerToCheck)
    {
        double priceToBeChecked = Convert.ToDouble(answerToCheck);
        if (priceToBeChecked <= 0)
        {
            Console.WriteLine("The Price cannot be lower than or equal to zero (0)");
            return false;
        }
        return true;
    }

    public int GetProductStock()
    {
        Console.WriteLine("Please input the amount of the product in stock");
        string answerToCheck = GetAnswer(Console.ReadLine());
        bool isDigit = CheckNumerical(answerToCheck);
        bool isValid = false;

        if (!isDigit)
        {
            Console.WriteLine("You have input an invalid type of data. You must enter a number");
        }
        else
        {
            if (CheckValidStock(answerToCheck))
            {
                isValid = true;
            }
        }
        while (isValid == false)
        {
            Console.WriteLine("The number of products in stock cannot be lower than zero (0). Please input a valid amount:");
            answerToCheck = GetAnswer(Console.ReadLine());
            isDigit = CheckNumerical(answerToCheck);

            if (!isDigit)
            {
                Console.WriteLine("You have input an invalid type of data. You must enter a number");
            }
            else
            {
                if (CheckValidStock(answerToCheck))
                {
                    isValid = true;
                }
            }
        }
        int productInStock = Convert.ToInt32(answerToCheck);
        return productInStock;
    }

    public bool CheckValidStock(string answerToCheck)
    {
        int stockToBeChecked = Convert.ToInt32(answerToCheck);
        if (stockToBeChecked < 0)
        {
            return false;
        }
        return true;
    }

    public string GetAnswer(string answerToCheck)
    {
        while (string.IsNullOrWhiteSpace(answerToCheck) || string.IsNullOrEmpty(answerToCheck))
        {
            Console.WriteLine("The Answer cannot be Null or Empty. Please input a valid answer:");
            answerToCheck = Console.ReadLine();
        }
        return answerToCheck;
    }

    public Product GetProductInput(List<Product> products)
    {
        int id = GetProductId(products);

        int categoryId = GetCategoryId();

        string name = GetProductName();

        double price = GetProductPrice();

        int stock = GetProductStock();

        Product createdProduct = new Product(id, categoryId, name, price, stock);

        return createdProduct;
    }

    public void GetAllProductNameContains(string text)
    {
        List<Product>filteredProducts = productData.GetAllProductNameContains(text);
        foreach (Product product in filteredProducts)
        {
            Console.WriteLine(product);
        }
    }

}
