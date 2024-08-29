using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.Model.DTO
{
    /// <summary>
    /// DTO для аккаунта.
    /// </summary>
    public class AccountDto
    {
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
