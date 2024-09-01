using EMessenger.Model;
using EMessenger.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.DataBaseContext.Interfaces
{
    /// <summary>
    /// Инткерфейс репозитория для работы с пользователем.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Добавить зарегистрировавшегося пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <param name="account">Аккаунт.</param>
        /// <returns></returns>
        Task Add(User user, Account account);

        /// <summary>
        /// Получить чаты поользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Чаты.</returns>
        IEnumerable<Chat> GetChatsByUserId(int userId);

        /// <summary>
        /// Получить последний записанный идентификатор.
        /// </summary>
        /// <returns>Последний идентификатор.</returns>
        Task<User> GetLastUser();

        /// <summary>
        /// Получить всех зарегистрировавшихся пользователей.
        /// </summary>
        /// <returns>Пользователи.</returns>
        IEnumerable<User> GetAllRegistered();
    }
}
