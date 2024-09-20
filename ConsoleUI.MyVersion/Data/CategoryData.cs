using ConsoleUI.MyVersion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.MyVersion.Data;

public class CategoryData
{
    List<Category> categories = new List<Category>()
    {
        new Category(1,"Clothing", "Things you wear"),
        new Category(2,"Electronics", "Ooo electric zappy"),
        new Category(3,"Decorations", "Art is Explosion"),
        new Category(4, "Sports Equipment", "Balls, gloves and sticks. What more could you want?")
    };

    public List<Category> GetAll()
    {
        return categories;
    }

    public Category? GetById(int id)
    {
        Category category = categories.SingleOrDefault(c => c.Id == id);
        return category;
    }

    public Category Add(Category category)
    {
        categories.Add(category);
        return category;
    }

    
}
