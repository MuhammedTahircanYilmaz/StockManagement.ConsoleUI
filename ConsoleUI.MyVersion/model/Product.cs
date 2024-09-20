namespace ConsoleUI.MyVersion.Model;

public record Product(
    int Id,
    int CategoryId,
    string Name,
    double Price,
    int Stock);