﻿using EMessenger.DataBaseContext.Interfaces;
using EMessenger.DataBaseContext.Repositories;
using EMessenger.Model.DTO;
using EMessenger.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EMessenger.Model.Enums;

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

        /// <summary>
        /// Репозиторий для работы с пользователем.
        /// </summary>
        private readonly IUserRepository userRepository;

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
            var lastChat = await chatRepository.GetLastChat();

            Chat chat = new Chat()
            {
                Id = lastChat == null ? 1 : lastChat.Id + 1,
                Name = chatDto.Name,
                Type = chatDto.Type,
            };

            await chatRepository.Add(chat);
            await chatRepository.SaveAsync();

            return Ok(chat.Id);
        }

        /// <summary>
        /// Удалить чат.
        /// </summary>
        /// <param name="chatId">Идентификатор чата.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteChat(int chatId)
        {
            Chat chat = await chatRepository.GetByIdAsync(chatId);

            if (chat == null)
                return BadRequest("Такого чата нет.");

            chatRepository.Delete(chat);
            await chatRepository.SaveAsync();

            return Ok();
        }

        /// <summary>
        /// Обновить чат.
        /// </summary>
        /// <param name="id">Идентификатор чата.</param>
        /// <param name="name">Название чата.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateChat(int id, string name)
        {
            Chat chat = await chatRepository.GetByIdAsync(id);

            if (chat == null)
                return BadRequest("Такого чата нет.");

            chat.Name = name;

            chatRepository.Update(chat);
            await chatRepository.SaveAsync();

            return Ok();
        }

        /// <summary>
        /// Добавить пользователя в чат.
        /// </summary>
        /// <param name="accountId">Id аккаунта.</param>
        /// <param name="chatId">Id чата.</param>
        /// <returns></returns>
        [HttpPost("AddAccountInChat")]
        public async Task<IActionResult> AddAccountInChat(int accountId, int chatId)
        {
            await chatRepository.AddAccountInChat(accountId, chatId);
            await chatRepository.SaveAsync();
            return Ok();
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

        /// <summary>
        /// Получить групповые чаты пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Групповые чаты пользователя.</returns>
        [HttpGet("GetGroupChats")]
        public IActionResult GetGroupChats(int userId)
        {
            List<ChatGroupDto> chats = new List<ChatGroupDto>();

            var response = userRepository
                .GetChatsByUserId(userId)
                .Where(x => x.Type == ChatType.Group)
                .ToList();
            response.ForEach(x => chats.Add(new ChatGroupDto() { Id = x.Id, Name = x.Name, Type = ChatType.Group, Accounts = x.Accounts }));

            return Ok(chats);
            //return NotFound();
        }

        /// <summary>
        /// Получить общие чаты.
        /// </summary>
        /// <returns>Общие чаты.</returns>
        [HttpGet("GetGeneralChats")]
        public IActionResult GetGeneralGhats()
        {
            List<ChatGroupDto> chats = new List<ChatGroupDto>();

            var response = chatRepository.GetGeneralChats().ToList();
            response.ForEach(x => chats.Add(new ChatGroupDto() { Id = x.Id, Name = x.Name }));

            return Ok(chats);
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="chatRepository">Репозиторий для работы с чатом.</param>
        public ChatController(IChatRepository chatRepository, IUserRepository userRepository)
        {
            this.chatRepository = chatRepository;
            this.userRepository = userRepository;
        }

        #endregion
    }
}
