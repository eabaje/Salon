
using Salon.Domain.Entities;

namespace Salon.Application.Extensions
{
    public static class UserExtensions
    {
        public static string FullName(this AppUser user)
        {
            return !string.IsNullOrWhiteSpace(user.Othernames) ? $"{user.LastName}, {user.Othernames}" : user.LastName;
        }
    }
}
