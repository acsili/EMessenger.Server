using EMessenger.DataBaseContext.Interfaces;
using EMessenger.Model;
using EMessenger.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace EMessenger.DataBaseContext.Repositories
{
    /// <summary>
    /// Репозиторий для работы с чатами.
    /// </summary>
    public class ChatRepository : IChatRepository
    {
        #region Поля и свойства

        /// <summary>
        /// Контекст данных.
        /// </summary>
        private readonly ApplicationDbContext context;

        #endregion

        #region Методы

        /// <summary>
        /// Добавить.
        /// </summary>
        /// <param name="entity">Чат.</param>
        /// <returns></returns>
        public async Task Add(Chat entity)
        {
            await context.Chats.AddAsync(entity);
        }

        /// <summary>
        /// Удалить.
        /// </summary>
        /// <param name="entity">Чат.</param>
        public void Delete(Chat entity)
        {
            context.Chats.Remove(entity);
        }

        /// <summary>
        /// Получить все чаты.
        /// </summary>
        /// <returns>Чаты.</returns>
        public async Task<IEnumerable<Chat?>> GetAllAsync()
        {
            return await context
                .Chats
                .Include(x => x.Messages)
                .Include(x => x.Accounts)
                .ToListAsync();
        }

        /// <summary>
        /// Получить все соощения из чата.
        /// </summary>
        /// <param name="chatId">Идентификатор чата.</param>
        /// <returns>Сообщения.</returns>
        public IEnumerable<Message> GetMessagesByIdAsync(int chatId)
        {
            return context.Chats.Include(x => x.Messages).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == chatId)?.Messages;
        }

        /// <summary>
        /// Получить чат по id.
        /// </summary>
        /// <param name="id">Id чата.</param>
        /// <returns>Чат.</returns>
        public async Task<Chat?> GetByIdAsync(int id)
        {
            return await context.Chats.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Получить общие чаты.
        /// </summary>
        /// <returns>Общие чаты.</returns>
        public IEnumerable<Chat> GetGeneralChats()
        {
            return context.Chats.Where(x => x.Type == ChatType.General);
        }

        /// <summary>
        /// Сохранить в БД.
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить.
        /// </summary>
        /// <param name="entity">Чат.</param>
        public void Update(Chat entity)
        {
            context.Chats.Update(entity);
        }

        /// <summary>
        /// Добавить пользователя в чат.
        /// </summary>
        /// <param name="accountId">Идентификатор пользователя.</param>
        /// <param name="chatId">Идентификатор чата.</param>
        /// <returns></returns>
        public async Task AddAccountInChat(int accountId, int chatId)
        {
            var chat = await context.Chats.FirstOrDefaultAsync(x => x.Id == chatId);
            var account = await context.Accounts.FirstOrDefaultAsync(x => x.Id == accountId);
            chat.Accounts.Add(account);
        }

        /// <summary>
        /// Получить последний чат.
        /// </summary>
        /// <returns>Чат.</returns>
        public async Task<Chat> GetLastChat()
        {
            return await context.Chats.OrderBy(x => x.Id).LastOrDefaultAsync();
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public ChatRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        #endregion
    }
}
