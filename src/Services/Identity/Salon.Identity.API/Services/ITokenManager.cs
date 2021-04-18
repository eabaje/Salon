using System;
using Salon.Identity.API.Models;

namespace Salon.Identity.API.Services
{
    public interface ITokenManager
    {
        TokenModel GetToken(Guid userId, string email, string role);

        Guid GetUserIdFromExpiredToken(string token);
    }
}
