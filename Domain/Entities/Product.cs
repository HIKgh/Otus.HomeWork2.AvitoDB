using Domain.Interfaces;

namespace Domain.Entities;

/// <summary>
/// Товар
/// </summary>
public class Product : IEntity<int>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Идентификатор типа товара
    /// </summary>
    public int IdProductType { get; set; }

    public ICollection<Annoucement> Annoucements { get; } = new List<Annoucement>();

    public ProductType ProductType { get; set; } = null!;
}
