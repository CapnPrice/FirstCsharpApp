using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapi.Interfaces;
using testapi.Models;

namespace testapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _IUserRepository;

        public UsersController(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }

        [HttpGet]
        [Route("ListAllUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _IUserRepository.GetAllUsers();
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult RegisterUser(UserRegisterModel request)
        {
            var userAdded = _IUserRepository.AddUser(request);
            if (!userAdded)
            {
                return BadRequest("Unable to add user");
            }
            return Ok("User Sucsesfully Create");
        }
    }
}
