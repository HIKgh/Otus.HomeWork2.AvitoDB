using Domain.Entities;
using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Interfaces;

namespace Services.Implementations;

public class ProductTypeService : IShowDbService, IProductTypeService
{
    private readonly ProductTypeRepository _repository;

    public ProductTypeService(DbContext context)
    {
        _repository = new ProductTypeRepository(context);
    }

    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine("Вывод таблицы типов товаров ProductType:");
        var productTypes = _repository.GetAll();
        foreach (var productType in productTypes)
        {
            Console.WriteLine($"Id:{productType.Id}, Name:{productType.Name}");
        }
        Console.WriteLine("Для продолжения нажмите любую клавишу...");
        Console.ReadKey();
    }

    public int Add(ProductTypeDto dto)
    {
        var productType = new ProductType { Name = dto.Name };
        var result = _repository.Add(productType);
        _repository.SaveChanges();
        return result.Id;
    }

    public void Update(int id, ProductTypeDto dto)
    {
        var result = _repository.Get(id);
        if (result != null)
        {
            result.Name = dto.Name;
            _repository.Update(result);
            _repository.SaveChanges();
        }
    }

    public bool Delete(int id)
    {
        var result = _repository.Delete(id);
        _repository.SaveChanges();
        return result;
    }

    public ProductTypeDto? Get(int id)
    {
        var result = _repository.Get(id);
        return result == null ? null : new ProductTypeDto { Name = result.Name };
    }
}