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
    /// Репозиторий для работы с аккаунтом.
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        #region Поля и свойства

        /// <summary>
        /// Контекст данных.
        /// </summary>
        private readonly ApplicationDbContext context;

        #endregion

        #region Методы

        /// <summary>
        /// Добавить.
        /// </summary>
        /// <param name="entity">Аккаунт.</param>
        /// <returns></returns>
        public async Task Add(Account entity)
        {
            await context.Accounts.AddAsync(entity);
        }

        public void Delete(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Сохранить.
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Account entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получить аккаунт по логину.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <returns>Аккаунт.</returns>
        public async Task<Account> GetByLogin(string login)
        {
            return await context.Accounts.FirstOrDefaultAsync(x => x.Login == login);
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public AccountRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        #endregion
    }
}
