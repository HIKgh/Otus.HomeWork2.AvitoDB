using Domain.Interfaces;

namespace Domain.Entities;

/// <summary>
/// Продавец
/// </summary>
public class Seller : IEntity<int>
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
    /// Телефон
    /// </summary>
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; set; } = null!;

    public ICollection<Annoucement> Annoucements { get; } = new List<Annoucement>();
}
