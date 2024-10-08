﻿using EMessenger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.DataBaseContext.Interfaces
{
    /// <summary>
    /// Инткерфейс репозитория для работы с чатом.
    /// </summary>
    public interface IChatRepository : IRepository<Chat>
    {
        /// <summary>
        /// Добавить пользователя в чат.
        /// </summary>
        /// <param name="accountId">Идентификатор пользователя.</param>
        /// <param name="chatId">Идентификатор чата.</param>
        /// <returns></returns>
        Task AddAccountInChat(int accountId, int chatId);

        /// <summary>
        /// Получить все соощения из чата.
        /// </summary>
        /// <param name="chatId">Идентификатор чата.</param>
        /// <returns>Сообщения.</returns>
        IEnumerable<Message> GetMessagesByIdAsync(int chatId);

        /// <summary>
        /// Получить общие чаты.
        /// </summary>
        /// <returns>Общие чаты.</returns>
        public IEnumerable<Chat> GetGeneralChats();

        /// <summary>
        /// Получить последний чат.
        /// </summary>
        /// <returns>Чат.</returns>
        Task<Chat> GetLastChat();
    }
}
