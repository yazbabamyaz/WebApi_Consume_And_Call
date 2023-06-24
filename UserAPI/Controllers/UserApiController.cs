using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        List<User> userList = new List<User>();
        public UserApiController()
        {
            userList.Add(new User { UserId = 1, Name = "Ali", Address = "İstanbul" });
            userList.Add(new User { UserId = 2, Name = "Ayşe", Address = "Ankara" });
            userList.Add(new User { UserId = 3, Name = "Veli", Address = "İzmir" });
            userList.Add(new User { UserId = 4, Name = "Sultan", Address = "Konya" });
        }
        [HttpGet]//api/userApi 
        public IActionResult GetUsers()
        {
            return Ok(userList);
        }

        [HttpGet("{id}")]//api/userApi
        public IActionResult GetUsers(int id)
        {
            User user= userList.Find(x=>x.UserId== id);
            return Ok(user);
        }
    }
}
