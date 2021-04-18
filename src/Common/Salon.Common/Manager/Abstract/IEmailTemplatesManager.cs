using System.Threading.Tasks;

namespace Salon.Common.Managers.Abstract
{
    public interface IEmailTemplatesManager
    {
        Task<string> ReadTemplateAsync(string templateName);
    }
}
