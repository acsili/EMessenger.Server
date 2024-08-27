using EMessenger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.DataBaseContext.Interfaces
{
    /// <summary>
    /// Инткерфейс репозитория для работы с полььзователем.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Получить пользователя по никнейму.
        /// </summary>
        /// <param name="nickname">Никнейм.</param>
        /// <returns>Пользователь.</returns>
        Task<User> GetByNickName(string nickname);
    }
}
