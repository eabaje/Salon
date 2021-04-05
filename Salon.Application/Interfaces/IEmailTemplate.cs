using Salon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Application.Interfaces
{
    public interface IEmailTemplateService
    {
        Task<IList<EmailTemplate>> GetAllEmailTemplates();

        Task<EmailTemplate> GetEmailTemplateById(int templateId);

        Task<EmailTemplate> GetEmailTemplateByName(string name);

        Task<int> InsertEmailTemplate(EmailTemplate template);

        Task UpdateEmailTemplate(EmailTemplate template);

       
    }
}
