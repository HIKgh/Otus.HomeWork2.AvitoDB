using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Implementations;

public class SellerService : IShowDbService
{
    private readonly SellerRepository _repository;

    public SellerService(DbContext context)
    {
        _repository = new SellerRepository(context);
    }

    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine("Вывод таблицы продавцов Seller:");
        var sellers = _repository.GetAll();
        foreach (var seller in sellers)
        {
            Console.WriteLine($"Id:{seller.Id}, Name:{seller.Name}, Phone:{seller.Phone}, Address:{seller.Address}");
        }
        Console.WriteLine("Для продолжения нажмите любую клавишу...");
        Console.ReadKey();
    }
}