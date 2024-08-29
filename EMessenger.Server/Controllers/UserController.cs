using EMessenger.DataBaseContext.Interfaces;
using EMessenger.Model;
using EMessenger.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EMessenger.Server.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователем.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Поля и свойства

        /// <summary>
        /// Репозиторий для работы с пользователем.
        /// </summary>
        private readonly IUserRepository userRepository;

        #endregion

        #region Методы

        /// <summary>
        /// Добавить пользователя.
        /// </summary>
        /// <param name="userDto">Пользователь.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPost("AddUser")]
        public  async Task<IActionResult> AddUser(UserDto userDto)
        {
            User user = new User()
            {
                NickName = userDto.NickName
            };
            await userRepository.Add(user);
            await userRepository.SaveAsync();
            return Ok();
            //return NotFound();
        }

        /// <summary>
        /// Добавить зарегистрировавшегося пользователя.
        /// </summary>
        
        [HttpPost("AddUserAccount")]
        public async Task<IActionResult> AddUserAccount(string nickname, string password, string login)
        {
            User user = new User()
            {
                NickName = nickname
            };
            Account account = new Account()
            {
                Password = password,
                Login = login,
                User = user
            };
            await userRepository.Add(user, account);
            await userRepository.SaveAsync();
            return Ok();
            //return NotFound();
        }

        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <returns>Статус запроса.</returns>
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await userRepository.GetAllAsync();
            return Ok(response);
        }

        /// <summary>
        /// Поулить чаты пользователя.
        /// </summary>
        /// <param name="userId">Id пользователя.</param>
        /// <returns>Чаты и статус запроса.</returns>
        [HttpGet("GetUserChats")]
        public IActionResult GetUserChats(int userId)
        {
            var response = userRepository.GetChatsByUserId(userId);
            return Ok(response);
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="userRepository">Репозиторий пользователя.</param>
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        #endregion
    }
}
