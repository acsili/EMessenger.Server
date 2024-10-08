﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.Model.DTO
{
    /// <summary>
    /// DTO для пользователя без регистрации.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Ник.
        /// </summary>
        public string? NickName { get; set; }
    }
}
