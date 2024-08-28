using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.Model.DTO
{
    /// <summary>
    /// DTO для сообщений.
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор чата.
        /// </summary>
        public int ChatId { get; set; }
    }
}
