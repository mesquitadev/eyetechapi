using Microsoft.AspNetCore.Authorization;

namespace EyeTech.Shipped.Api.OAuth
{
    public class Auth : AuthorizeAttribute
    {
        public Auth(string policy = "Bearer")
        {
            this.AuthenticationSchemes = policy;
        }
    }
}