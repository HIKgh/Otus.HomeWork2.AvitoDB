using Domain.Interfaces;

namespace Domain.Entities;

/// <summary>
/// Тип товара
/// </summary>
public class ProductType : IEntity<int>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; } = new List<Product>();
}
