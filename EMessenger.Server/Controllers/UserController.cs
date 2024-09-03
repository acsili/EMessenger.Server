using EMessenger.DataBaseContext.Interfaces;
using EMessenger.Model;
using EMessenger.Model.DTO;
using EMessenger.Model.Enums;
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

        /// <summary>
        /// Репозиторий для работы с чатом.
        /// </summary>
        private readonly IChatRepository chatRepository;

        #endregion

        #region Методы

        /// <summary>
        /// Добавить пользователя.
        /// </summary>
        /// <param name="userDto">Пользователь.</param>
        /// <returns>Статус запроса. Id пользователя.</returns>
        [HttpPost("Add")]
        public  async Task<IActionResult> Add(UserDto userDto)
        {
            var lastUser = await userRepository.GetLastUser();

            User user = new User()
            {
                Id = lastUser == null ? 1 : lastUser.Id + 1,
                NickName = userDto.NickName
            };
            await userRepository.Add(user);
            await userRepository.SaveAsync();

            return Ok(user.Id);
            //return NotFound();
        }

        /// <summary>
        /// Добавить зарегистрировавшегося пользователя.
        /// </summary>
        /// <param name="userRegistrationDto">Пользователь.</param>
        /// <returns>Id пользователя.</returns>
        [HttpPost("AddWithAccount")]
        public async Task<IActionResult> AddWithAccount(UserRegistrationDto userRegistrationDto)
        {
            var users = userRepository.GetAllRegistered(); 
            if (users != null)
            {
                foreach (var u in users)
                {
                    if (u.Account.Login == userRegistrationDto.Login)
                        return BadRequest("Такой логин уже есть.");
                }
            }

            var lastUser = await userRepository.GetLastUser();

            User user = new User()
            {
                Id = lastUser == null ? 1 : lastUser.Id + 1,
                NickName = userRegistrationDto.NickName
            };

            Account account = new Account()
            {
                Id = user.Id,
                Password = userRegistrationDto.Password,
                Login = userRegistrationDto.Login,
                UserId = user.Id
            };

            await userRepository.Add(user, account);
            await userRepository.SaveAsync();

            return Ok(user.Id);
        }

        /// <summary>
        /// Удалить ползователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int userId)
        {
            User user = await userRepository.GetByIdAsync(userId);

            if (user == null)
                return BadRequest("Такого пользователя нет.");

            userRepository.Delete(user);
            await userRepository.SaveAsync();

            return Ok();
        }

        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <returns>Статус запроса.</returns>
        [HttpGet("GetAll")]
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

        /// <summary>
        /// Получить пользователя по логину и паролю.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Пользователь.</returns>
        [HttpGet("GetByLoginAndPassword")]
        public async Task<IActionResult> GetByLoginAndPassword(string login, string password)
        {
            Account account = await accountRepository.GetByLogin(login);
            if (account != null && account.Password == password)
            {
                User user = await userRepository.GetByIdAsync(account.Id);
                UserAuthorizationDto userAuthorizationDto = new UserAuthorizationDto()
                {
                    Id = account.Id,
                    NickName = user.NickName
                };
                return Ok(userAuthorizationDto);
            }
            return BadRequest("Неверный пароль.");
        }

        /// <summary>
        /// Получить всех зарегистрировавшихся пользователей.
        /// </summary>
        /// <returns>Пользователи.</returns>
        [HttpGet("GetAllRegistred")]
        public IActionResult GetAllRegistred()
        {
            var response = userRepository.GetAllRegistered();
            return Ok(response);
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="userRepository">Репозиторий пользователя.</param>
        public UserController(IUserRepository userRepository, IAccountRepository accountRepository, IChatRepository chatRepository)
        {
            this.userRepository = userRepository;
            this.accountRepository = accountRepository;
            this.chatRepository = chatRepository;
        }

        #endregion
    }
}
