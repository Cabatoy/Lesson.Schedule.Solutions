using Saas.Entities.Generic;

namespace Saas.Entities.Dto
{
    public class UserForLoginDto :IDto
    {
       
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
