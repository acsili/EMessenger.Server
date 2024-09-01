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
    /// Репозиторий для работы с сообщениями.
    /// </summary>
    public class MessageRepository : IMessageRepository
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
        /// <param name="entity">Сообщение.</param>
        /// <returns></returns>
        public async Task Add(Message entity)
        {
            await context.Messages.AddAsync(entity);
        }

        /// <summary>
        /// Удалить.
        /// </summary>
        /// <param name="entity">Сообщение.</param>
        public void Delete(Message entity)
        {
            context.Messages.Remove(entity);
        }

        /// <summary>
        /// Получить все сообщение.
        /// </summary>
        /// <returns>Сообщения.</returns>
        public async Task<IEnumerable<Message?>> GetAllAsync()
        {
            return await context.Messages.Include(x => x.User).ToListAsync();
        }

        /// <summary>
        /// Получить сообщение по id.
        /// </summary>
        /// <param name="id">Id сообщения.</param>
        /// <returns>Сообщение.</returns>
        public async Task<Message?> GetByIdAsync(int id)
        {
            return await context.Messages.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Сохранить в БД.
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить.
        /// </summary>
        /// <param name="entity">Сообщение.</param>
        public void Update(Message entity)
        {
            context.Messages.Update(entity);
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public MessageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        #endregion
    }
}
