using ConsoleUI.MyVersion.Data;
using ConsoleUI.MyVersion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.MyVersion.Service;

internal class CategoryServiceMV
{

    CategoryData categoryData = new CategoryData();

    public void Add(Category category)
    {
        categoryData.Add(category);
        Console.WriteLine("The category has been added");
        Console.WriteLine(category);
    }

    public void GetAll()
    {
        List<Category> categories = categoryData.GetAll();

        categories.ForEach(c =>
        {
            Console.WriteLine(c);
        });
    }
    public List<Category> GetAllCategories()
    {
        return categoryData.GetAll();
    }

    public void GetById(int id)
    {
        Category category = categoryData.GetById(id);
        Console.WriteLine($"The Category with the Id ({id}) is:");
        Console.WriteLine(category);

    }
}

