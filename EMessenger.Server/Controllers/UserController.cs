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
        [HttpPost]
        public IActionResult AddUser(UserDto userDto)
        {
            User user = new User()
            {
                NickName = userDto.NickName,
                CreatedAt = DateTime.Now,
            };
            var response = userRepository.Add(user);
            if (response)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <returns>Статус запроса.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await userRepository.GetAllAsync();
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
