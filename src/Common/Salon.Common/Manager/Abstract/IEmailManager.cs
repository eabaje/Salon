using System.Threading.Tasks;

namespace Salon.Common.Managers.Abstract
{
    public interface IEmailManager
    {
        Task SendAsync(string receiverAddress, string receiverName, string subject, string body);
    }
}
