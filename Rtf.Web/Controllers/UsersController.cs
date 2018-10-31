using Microsoft.AspNetCore.Mvc;

namespace Rtf.Web.Controllers
{
    using Data.Abstractions.Repository;
    using DTO;

    /// <summary>
    /// Пользователи
    /// </summary>
    
    public class UsersController: Controller
    {
        private IUsersRepository _repository;
        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="dto">Регистрационные данные</param>
        /// <returns>Пользователь</returns>
        [HttpPost("/users/register")]
        public UserDto Register(UserRegistrationDto dto)
        {
            _repository.RegisterUser(dto.Name, dto.Login, dto.Password);
            var user = _repository.GetUser(dto.Login, dto.Password);
            return new UserDto { Id = user.Id, Name = user.Name };
        }
    }
}
