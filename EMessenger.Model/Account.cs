using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.Model
{
    /// <summary>
    /// Аккаунт.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string? Login { get; set; }  

        /// <summary>
        /// Пароль.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Поьлзователь.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Список чатов.
        /// </summary>
        public List<Chat> Chats { get; set; } = new();
    }
}
