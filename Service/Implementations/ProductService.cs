using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Implementations;

public class ProductService : IShowDbService
{
    private readonly ProductRepository _repository;

    public ProductService(DbContext context)
    {
        _repository = new ProductRepository(context);
    }

    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine("Вывод таблицы товаров Product:");
        var products = _repository.GetAll();
        foreach (var product in products)
        {
            
            Console.WriteLine($"Id:{product.Id}, Name:{product.Name}, ProductType:{product.ProductType.Name}");
        }
        Console.WriteLine("Для продолжения нажмите любую клавишу...");
        Console.ReadKey();
    }
}