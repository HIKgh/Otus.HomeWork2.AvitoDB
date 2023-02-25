using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Implementations;

public class AnnoucementService : IShowDbService
{
    private readonly AnnoucementRepository _repository;

    public AnnoucementService(DbContext context)
    {
        _repository = new AnnoucementRepository(context);
    }

    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine("Вывод таблицы объявлений Annoucement:");
        var annoucements = _repository.GetAll();
        foreach (var annoucement in annoucements)
        {
            Console.WriteLine($"Id:{annoucement.Id}, Seller:{annoucement.Seller.Name}, Products:{annoucement.Product.Name}, PublishDatetime:{annoucement.PublishDatetime}, Headline:{annoucement.Headline}, Description:{annoucement.Description}, Price:{annoucement.Price}, IsClose:{annoucement.IsClose}");
        }
        Console.WriteLine("Для продолжения нажмите любую клавишу...");
        Console.ReadKey();
    }
}