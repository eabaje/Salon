using System;
using System.IO;
using System.Threading.Tasks;
using Salon.Common.Exceptions;
using Salon.Common.Managers.Abstract;

namespace Salon.Common.Managers.Implementations
{
    internal class EmailTemplatesManager : IEmailTemplatesManager
    {
        private readonly IPathManager pathManager;

        public EmailTemplatesManager(IPathManager pathManager)
        {
            this.pathManager = pathManager;
        }

        public async Task<string> ReadTemplateAsync(string templateName)
        {
            var templatePath = pathManager.GetEmailTemplatePath(templateName);
            if (!File.Exists(templatePath))
            {
                throw new SalonException(ErrorCode.EmailTemplateNotExists(templateName));
            }

            var emailTemplate = await File.ReadAllTextAsync(templatePath);
            if (string.IsNullOrEmpty(emailTemplate))
            {
                throw new Exception($"Cannot read email template from path: '{templateName}'.");
            }

            return emailTemplate;
        }
    }
}
