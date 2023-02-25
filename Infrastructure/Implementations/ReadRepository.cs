using Domain.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;


/// <summary>
/// Репозиторий для чтения
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
/// <typeparam name="TPrimaryKey">Основной ключ</typeparam>
public abstract class ReadRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey>
    where T : class, IEntity<TPrimaryKey>
{
    protected readonly DbContext Context;
    protected DbSet<T> EntitySet;

    protected ReadRepository(DbContext context)
    {
        Context = context;
        EntitySet = Context.Set<T>();
    }

    /// <summary>
    /// Запросить все сущности в базе
    /// </summary>
    /// <param name="asNoTracking">Вызвать с AsNoTracking</param>
    /// <returns>IQueryable массив сущностей</returns>
    public virtual IQueryable<T> GetAll(bool asNoTracking = false)
    {
        return asNoTracking ? EntitySet.AsNoTracking() : EntitySet;
    }

    /// <summary>
    /// Получить сущность по ID
    /// </summary>
    /// <param name="id">ID сущности</param>
    /// <returns>сущность</returns>
    public virtual T Get(TPrimaryKey id)
    {
        return EntitySet.Find(id);
    }
}