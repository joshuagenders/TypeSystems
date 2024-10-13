using Microsoft.AspNetCore.Mvc;
using TypeSystems.Models;

namespace TypeSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ILogger<UserController> logger) : ControllerBase
    {
        [HttpPost]
        public async Task Add(User user)
        {
            await Task.Delay(1);
            logger.LogInformation("User added with phone number {phoneNumber}", user.PhoneNumber);
        }
    }
}
