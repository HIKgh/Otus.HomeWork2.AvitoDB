using Domain.Interfaces;

namespace Infrastructure.Interfaces;

/// <summary>
/// Интерфейс репозитория, предназначенного для чтения
/// </summary>
/// <typeparam name="T">Тип Entity для репозитория</typeparam>
/// <typeparam name="TPrimaryKey">тип первичного ключа</typeparam>
public interface IReadRepository<out T, in TPrimaryKey> : IRepository where T : IEntity<TPrimaryKey>
{
    /// <summary>
    /// Запросить все сущности в базе
    /// </summary>
    /// <param name="noTracking">Вызвать с AsNoTracking</param>
    /// <returns>IQueryable массив сущностей</returns>
    IQueryable<T> GetAll(bool noTracking = false);

    /// <summary>
    /// Получить сущность по ID
    /// </summary>
    /// <param name="id">ID сущности</param>
    /// <returns>сущность</returns>
    T Get(TPrimaryKey id);
}