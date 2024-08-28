using EMessenger.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.Model.DTO
{
    /// <summary>
    /// DTO для чата.
    /// </summary>
    public class ChatDto
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Тип чата.
        /// </summary>
        public ChatType Type { get; set; }
    }
}
