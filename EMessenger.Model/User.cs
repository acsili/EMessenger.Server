using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ник.
        /// </summary>
        public string? NickName { get; set; }

        /// <summary>
        /// Дата создания пользователя.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Аккаунт.
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Список сообщений.
        /// </summary>
        public List<Message> Messages { get; set; } = new();

        /// <summary>
        /// Список чатов.
        /// </summary>
        public List<Chat> Chats { get; set; } = new();

    }
}
