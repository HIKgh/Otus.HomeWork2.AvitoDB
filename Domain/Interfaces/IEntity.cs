namespace Domain.Interfaces;

/// <summary>
/// Интерфейс сущности с идентификатором
/// </summary>
/// <typeparam name="TPrimaryKey">Тип идентификатора</typeparam>
public interface IEntity<TPrimaryKey>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    TPrimaryKey Id { get; set; }
}
