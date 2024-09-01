using EMessenger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.DataBaseContext.Interfaces
{
    /// <summary>
    /// Инткерфейс репозитория для работы с аккаунтом.
    /// </summary>
    public interface IAccountRepository : IRepository<Account>
    {
        /// <summary>
        /// Получить аккаунт по логину.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <returns>Аккаунт.</returns>
        Task<Account> GetByLogin(string login);
    }
}
