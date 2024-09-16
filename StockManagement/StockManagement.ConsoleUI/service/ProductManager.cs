using StockManagement.ConsoleUI.model;
using System;

namespace StockManagement.ConsoleUI.service;

public class ProductManager
{
    Product Product;
    List<Product> Products;

    public ProductManager()
    {

    }

    public ProductManager( List<Product> products)
    {
        Products = products;
    }


    public int GetProductId(List<Product> products)
    {
        bool isUnique = false;

        Console.WriteLine("Please input Product Id:");

        string answerToCheck = GetAnswer(Console.ReadLine());
        int givenId = Convert.ToInt32(answerToCheck);

        if (CheckValidId(givenId))
        {
            isUnique = true;
        }

        while (isUnique == false)
        {
            Console.WriteLine($"Product Id must be unique. The Id you are trying to input is \"{givenId}\"");
            Console.WriteLine("Please input valid Product Id:");
            answerToCheck = GetAnswer(Console.ReadLine());
            givenId = Convert.ToInt32(answerToCheck);
            if (CheckValidId(givenId))
            {
                isUnique = true;
            }
        }
        return givenId;
    }

    public bool CheckValidId(int id)
    {
        if (id <= 0)
        {
            return false;
        }

        foreach (Product product in Products)
        {
            if (product.Id == id)
            {
                return false;
            }
        }

        return true;
    }

    public string GetProductName()
    {
        Console.WriteLine("Please input a Product Name: ");
        string productName = "";
        while (productName.Length == 0 || string.IsNullOrWhiteSpace(productName))
        {
            Console.WriteLine("The Product Name cannot be empty. Please input a valid name");
            productName = Console.ReadLine();
        }
        return productName;
    }

    public double GetProductPrice()
    {
        Console.WriteLine("Please input the Product Price:");
        string answerToCheck = GetAnswer(Console.ReadLine());
        double productprice = Convert.ToDouble(answerToCheck);
    
        while (productprice <= 0)
        {
            Console.WriteLine("The Product Price cannot be lower than or equal to zero (0). Please input a valid price:");
            answerToCheck = GetAnswer(Console.ReadLine());
            productprice = Convert.ToDouble(answerToCheck);
        }
        return productprice;
    }

    public int GetProductStock()
    {
        Console.WriteLine("Please input the amount of the product in stock");
        string answerToCheck = GetAnswer(Console.ReadLine());
        int productInStock = Convert.ToInt32(answerToCheck);
        while(productInStock < 0)
        {
            Console.WriteLine("The number of products in stock cannot be lower than zero (0). Please input a valid amount:");
            answerToCheck = GetAnswer(Console.ReadLine());
            productInStock = Convert.ToInt32(answerToCheck);
        }
        return productInStock;
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
}