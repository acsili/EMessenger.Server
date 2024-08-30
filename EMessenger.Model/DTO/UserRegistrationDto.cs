using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.Model.DTO
{
    /// <summary>
    /// DTO для пользователя с регистрацией.
    /// </summary>
    public class UserRegistrationDto
    {
        /// <summary>
        /// Ник.
        /// </summary>
        public string? NickName { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string? Password { get; set; }
    }
}
