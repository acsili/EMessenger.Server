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
        public async Task Add(User entity)
        {
            await context.Users.AddAsync(entity);
        }

        /// <summary>
        /// Добавить зарегистрировавшегося пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <param name="account">Аккаунт.</param>
        /// <returns></returns>
        public async Task Add(User user, Account account)
        {
            await context.Users.AddAsync(user);
            await context.Accounts.AddAsync(account);
        }

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="entity">Пользователь.</param>
        /// <returns></returns>
        public void Delete(User entity)
        {
            context.Users.Remove(entity);
        }

        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User?>> GetAllAsync()
        {
            var users = await context
                .Users
                .Include(x => x.Account)
                .Include(x => x.Messages)
                .ToListAsync();
            return users;
        }

        /// <summary>
        /// Получить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns></returns>
        public async Task<User?> GetByIdAsync(int id)
        {
            return await context
                .Users
                .FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить.
        /// </summary>
        /// <param name="entity">Пользователь.</param>
        /// <returns></returns>
        public void Update(User entity)
        {
            context.Users.Update(entity);
        }

        /// <summary>
        /// Получить чаты пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Чаты.</returns>
        public IEnumerable<Chat> GetChatsByUserId(int userId)
        {
            return context.Accounts
                .Include(x => x.Chats)
                .FirstOrDefault(x => x.UserId == userId)
                .Chats;
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
