using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
