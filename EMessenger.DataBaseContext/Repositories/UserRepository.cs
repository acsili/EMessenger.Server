using EMessenger.DataBaseContext.Interfaces;
using EMessenger.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.DataBaseContext.Repositories
{
    /// <summary>
    /// Репозиторий для работы с пользователем.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        #region Поля и свойства

        /// <summary>
        /// Контекст данных.
        /// </summary>
        private readonly ApplicationDbContext context;

        #endregion

        #region Методы

        /// <summary>
        /// Добавить пользователя.
        /// </summary>
        /// <param name="entity">Пользователь</param>
        /// <returns></returns>
        public bool Add(User entity)
        {
            context.Users.Add(entity);
            return Save();
        }

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="entity">Пользователь.</param>
        /// <returns></returns>
        public bool Delete(User entity)
        {
            context.Users.Remove(entity);
            return Save();
        }

        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User?>> GetAllAsync()
        {
            return await context.Users.ToArrayAsync();
        }

        /// <summary>
        /// Получить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns></returns>
        public async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Получить пользователя по никнейму.
        /// </summary>
        /// <param name="nickname">Пользователь.</param>
        /// <returns></returns>
        public async Task<User?> GetByNickName(string nickname)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.NickName == nickname);
        }

        /// <summary>
        /// Сохранить данные в БД.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            int saved = context.SaveChanges();
            return saved > 0;
        }

        /// <summary>
        /// Обновить.
        /// </summary>
        /// <param name="entity">Пользователь.</param>
        /// <returns></returns>
        public bool Update(User entity)
        {
            context.Users.Update(entity);
            return Save();
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        #endregion
    }
}
