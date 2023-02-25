using Domain.Interfaces;

namespace Domain.Entities;

/// <summary>
/// Объявление
/// </summary>
public class Annoucement : IEntity<int>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор продавца
    /// </summary>
    public int IdSeller { get; set; }

    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public int IdProduct { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Дата и время
    /// </summary>
    public DateTime PublishDatetime { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Заголовок
    /// </summary>
    public string Headline { get; set; } = null!;

    /// <summary>
    /// Закрыто
    /// </summary>
    public bool IsClose { get; set; }

    public Product Product { get; set; } = null!;

    public Seller Seller { get; set; } = null!;
}
