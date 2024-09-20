namespace StockManagement.ConsoleUI.model;

public record Product(
    int Id,
    int CategoryId,
    string Name,
    double Price,
    int Stock);