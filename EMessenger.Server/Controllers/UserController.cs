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

        /// <summary>
        /// Репозиторий для работы с аккаунтом.
        /// </summary>
        private readonly IAccountRepository accountRepository;

        #endregion

        #region Методы

        /// <summary>
        /// Добавить пользователя.
        /// </summary>
        /// <param name="userDto">Пользователь.</param>
        /// <returns>Статус запроса. Id пользователя.</returns>
        [HttpPost("AddUser")]
        public  async Task<IActionResult> AddUser(UserDto userDto)
        {
            User user = new User()
            {
                NickName = userDto.NickName
            };
            await userRepository.Add(user);
            await userRepository.SaveAsync();

            var lastUser = await userRepository.GetLastUser();

            return Ok(lastUser.Id);
            //return NotFound();
        }

        /// <summary>
        /// Добавить зарегистрировавшегося пользователя.
        /// </summary>
        /// <param name="userRegistrationDto">Пользователь.</param>
        /// <returns>Id пользователя.</returns>
        [HttpPost("AddUserAccount")]
        public async Task<IActionResult> AddUserAccount(UserRegistrationDto userRegistrationDto)
        {
            User user = new User()
            {
                NickName = userRegistrationDto.NickName
            };

            await userRepository.Add(user);
            await userRepository.SaveAsync();

            var lastUser = await userRepository.GetLastUser();

            Account account = new Account()
            {
                Id = lastUser.Id,
                Password = userRegistrationDto.Password,
                Login = userRegistrationDto.Login,
                User = lastUser
            };

            await accountRepository.Add(account);
            await accountRepository.SaveAsync();

            return Ok(lastUser.Id);
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
        public UserController(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            this.userRepository = userRepository;
            this.accountRepository = accountRepository;
        }

        #endregion
    }
}
