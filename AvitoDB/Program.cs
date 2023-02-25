using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Implementations;

namespace AvitoDB;

class AvitoWork
{
    private const string DefaultProductType = "Default Product Type";
    
    private static ProductTypeService _productTypeService = null!;

    private static ProductService _productService = null!;

    private static SellerService _sellerService = null!;

    private static AnnoucementService _annoucementService = null!;

    static void Main()
    {
        ProgressMenu();
    }

    static void InitServicesTransient(DbContext db)
    {
        _productTypeService = new ProductTypeService(db);
        _productService = new ProductService(db);
        _sellerService = new SellerService(db);
        _annoucementService = new AnnoucementService(db);
    }

    static void ShowDb(DbContext db)
    {
        InitServicesTransient(db);
        _productTypeService.Show();
        _productService.Show();
        _sellerService.Show();
        _annoucementService.Show();
    }

    static void AddProductType(DbContext db)
    {
        _productTypeService = new ProductTypeService(db);
        Console.WriteLine("Введите наименование:");
        var name = Console.ReadLine() ?? DefaultProductType;
        var id = _productTypeService.Add(new ProductTypeDto { Name = name });
        Console.WriteLine($"Добавлена запись Id:{id}, Name:{name}");
        Console.ReadKey();
    }

    static void UpdateProductType(DbContext db)
    {
        _productTypeService = new ProductTypeService(db);
        Console.WriteLine("Введите идентификатор:");
        var idString = Console.ReadLine();
        if (int.TryParse(idString, out var id))
        {
            if (_productTypeService.Get(id) != null)
            {
                Console.WriteLine("Введите наименование:");
                var name = Console.ReadLine() ?? DefaultProductType;
                _productTypeService.Update(id, new ProductTypeDto { Name = name });
                Console.WriteLine($"Изменена запись Id:{id}");
            }
            else
            {
                Console.WriteLine("Идентификатор не найден в базе данных");
            }
        }
        else
        {
            Console.WriteLine("Некорректный идентификатор");
        }
        Console.ReadKey();
    }

    static void DeleteProductType(DbContext db)
    {
        _productTypeService = new ProductTypeService(db); ;
        Console.WriteLine("Введите идентификатор:");
        var idString = Console.ReadLine();
        if (int.TryParse(idString, out var id))
        {
            Console.WriteLine(_productTypeService.Delete(id)
                ? $"Удалена запись Id:{id}"
                : $"Не удалось удалить запись Id:{id}");
        }
        else
        {
            Console.WriteLine("Некорректный идентификатор:");
        }
        Console.ReadKey();
    }

    static void ProgressMenu()
    {
        int result;
        do
        {
            Console.Clear();
            Console.WriteLine("Выберите номер операции 0..4");
            Console.WriteLine("0 Выход");
            Console.WriteLine("1 Вывести содержимое таблиц базы данных");
            Console.WriteLine("2 Добавить запись в таблицу ProductType");
            Console.WriteLine("3 Удалить запись из таблицы ProductType");
            Console.WriteLine("4 Изменить запись таблицы ProductType");
            if (int.TryParse(Console.ReadLine(), out result) && result is >= 1 and <= 4)
            {
                using var db = new AvitoDbContext();
                try
                {
                    switch (result)
                    {
                        case 1:
                            ShowDb(db);
                            break;
                        case 2:
                            AddProductType(db);
                            break;
                        case 3:
                            DeleteProductType(db);
                            break;
                        case 4:
                            UpdateProductType(db);
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Произошла ошибка {exception.Message}");
                    Console.ReadKey();
                }
            }
        }
        while (result != 0);
    }
}