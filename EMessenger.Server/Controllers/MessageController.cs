using EMessenger.DataBaseContext.Interfaces;
using EMessenger.Model.DTO;
using EMessenger.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMessenger.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с сообщениями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        #region Поля и свойства

        /// <summary>
        /// Репозиторий для работы с сообщениями.
        /// </summary>
        private readonly IMessageRepository messageRepository;

        #endregion

        #region Методы

        /// <summary>
        /// Добавить сообщение.
        /// </summary>
        /// <param name="messageDto">Сообщение.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPost("AddMessage")]
        public async Task<IActionResult> AddMessage(MessageDto messageDto)
        {
            Message message = new Message()
            {
                Text = messageDto.Text,
                UserId = messageDto.UserId,
                ChatId = messageDto.ChatId
            };
            await messageRepository.Add(message);
            await messageRepository.SaveAsync();
            return Ok();
            //return NotFound();
        }

        /// <summary>
        /// Получить все сообщения.
        /// </summary>
        /// <returns>Статус запроса.</returns>
        [HttpGet("GetAllMessages")]
        public async Task<IActionResult> GetAllMessages()
        {
            var response = await messageRepository.GetAllAsync();
            return Ok(response);
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="messageRepository">Репозиторий сообщений.</param>
        public MessageController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        #endregion
    }
}
