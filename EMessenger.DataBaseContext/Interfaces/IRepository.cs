using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.DataBaseContext.Interfaces
{
    /// <summary>
    /// Базовый репозиторий для работы с сущностями из БД
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Получить все сущности из БД асинхронно.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        Task<IEnumerable<T?>> GetAllAsync();

        /// <summary>
        /// Получить сущность из БД асинхронно.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность.</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Добавить сущность в БД.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Результат добавления.</returns>
        bool Add(T entity);

        /// <summary>
        /// Обновить сущность в БД.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Результат обновления.</returns>
        bool Update(T entity);

        /// <summary>
        /// Удалить сущность из БД.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Результат удаления.</returns>
        bool Delete(T entity);

        /// <summary>
        /// Сохранить все изменения в БД.
        /// </summary>
        /// <returns>Результат сохранения.</returns>
        bool Save();
    }
}
