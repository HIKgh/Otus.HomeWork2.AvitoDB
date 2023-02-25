using Domain.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

/// <summary>
/// Репозиторий чтения и записи
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
/// <typeparam name="TPrimaryKey">Основной ключ</typeparam>
public abstract class Repository<T, TPrimaryKey> : ReadRepository<T, TPrimaryKey>, IRepository<T, TPrimaryKey> where T
    : class, IEntity<TPrimaryKey>
{
    protected Repository(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Удалить сущность
    /// </summary>
    /// <param name="id">ID удалённой сущности</param>
    /// <returns>была ли сущность удалена</returns>
    public virtual bool Delete(TPrimaryKey id)
    {
        var obj = EntitySet.Find(id);
        if (obj == null)
        {
            return false;
        }

        EntitySet.Remove(obj);
        return true;
    }

    /// <summary>
    /// Для сущности проставить состояние - что она изменена
    /// </summary>
    /// <param name="entity">сущность для изменения</param>
    public virtual void Update(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    /// <summary>
    /// Добавить в базу одну сущность
    /// </summary>
    /// <param name="entity">сущность для добавления</param>
    /// <returns>добавленная сущность</returns>
    public virtual T Add(T entity)
    {
        var objToReturn = Context.Set<T>().Add(entity);
        return objToReturn.Entity;
    }

    /// <summary>
    /// Сохранить изменения
    /// </summary>
    public virtual void SaveChanges()
    {
        Context.SaveChanges();
    }
}