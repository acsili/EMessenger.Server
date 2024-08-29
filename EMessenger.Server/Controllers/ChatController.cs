using EMessenger.DataBaseContext.Interfaces;
using EMessenger.DataBaseContext.Repositories;
using EMessenger.Model.DTO;
using EMessenger.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMessenger.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователем.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region Поля и свойства

        /// <summary>
        /// Репозиторий для работы с чатом.
        /// </summary>
        private readonly IChatRepository chatRepository;

        #endregion

        #region Методы

        /// <summary>
        /// Добавить чат.
        /// </summary>
        /// <param name="chatDto">Чат.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPost("AddChat")]
        public async Task<IActionResult> AddChat(ChatDto chatDto)
        {
            Chat chat = new Chat()
            {
                Name = chatDto.Name,
                Type = chatDto.Type,
            };
            await chatRepository.Add(chat);
            await chatRepository.SaveAsync();
            return Ok();
            //return NotFound();
        }

        /// <summary>
        /// Добавить пользователя в чат.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="chatId"></param>
        /// <returns></returns>
        [HttpPost("AddAccountInChat")]
        public async Task<IActionResult> AddAccountInChat(int accountId, int chatId)
        {
            await chatRepository.AddAccountInChat(accountId, chatId);
            await chatRepository.SaveAsync();
            return Ok();
            //return NotFound();
        }

        /// <summary>
        /// Получить все чаты.
        /// </summary>
        /// <returns>Чаты.</returns>
        [HttpGet("GetAllChats")]
        public async Task<IActionResult> GetAllChats()
        {
            var response = await chatRepository.GetAllAsync();
            return Ok(response);
            //return NotFound();
        }

        /// <summary>
        /// Получить все соощения из чата.
        /// </summary>
        /// <param name="chatId">Идентификатор чата.</param>
        /// <returns>Сообщения.</returns>
        [HttpGet("GetChatMessages")]
        public IActionResult GetChatMessages(int chatId)
        {
            var response = chatRepository.GetMessagesByIdAsync(chatId);
            return Ok(response);
            //return NotFound();
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="chatRepository">Репозиторий для работы с чатом.</param>
        public ChatController(IChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        #endregion
    }
}
