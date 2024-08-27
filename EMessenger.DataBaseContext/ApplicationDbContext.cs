using EMessenger.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.DataBaseContext
{
    /// <summary>
    /// Контекст данных.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        #region Поля и свойства

        /// <summary>
        /// Пользователи в БД.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Аккаунты в БД.
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Чаты в БД.
        /// </summary>
        public DbSet<Chat> Chats { get; set; }

        /// <summary>
        /// Сообщения в БД.
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор для подключения и настройки БД.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        #endregion
    }
}
