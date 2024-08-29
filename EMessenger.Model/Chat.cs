using EMessenger.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.Model
{
    /// <summary>
    /// Чат.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Тип чата.
        /// </summary>
        public ChatType Type { get; set; }

        /// <summary>
        /// Список пользователей чата.
        /// </summary>
        public List<Account> Accounts { get; set; } = new();

        /// <summary>
        /// Список сообщений.
        /// </summary>
        public List<Message> Messages { get; set; } = new();
    }
}
