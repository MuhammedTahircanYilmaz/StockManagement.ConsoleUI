namespace StockManagement.ConsoleUI.model;

public record Product(
    int Id,
    string Name,
    double Price,
    int Stock);