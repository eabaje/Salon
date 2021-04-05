using System.Security.Principal;

namespace Salon.CustomerBase.Interfaces
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}
