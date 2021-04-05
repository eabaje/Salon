using Salon.Application.Interfaces;
using Salon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Application.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly IBaseEmailTemplate<EmailTemplate> _repository;

        public EmailTemplateService(IBaseEmailTemplate<EmailTemplate> repository)
        {
            _repository = repository;
        }

        public async Task<IList<EmailTemplate>> GetAllEmailTemplates()
        {
            var query = _repository.Entities;

            return await query.ToListAsync();
        }

        public async Task<EmailTemplate> GetEmailTemplateById(int templateId)
        {
            var query = _repository.Entities
                .Where(x => x.Id == templateId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<EmailTemplate> GetEmailTemplateByName(string name)
        {
            var query = _repository.Entities
                .Where(x => x.Name == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> InsertEmailTemplate(EmailTemplate template)
        {
            _repository.Entities.Add(template);
            await _repository.SaveChangesAsync();

            return template.Id;
        }

        public async Task UpdateEmailTemplate(EmailTemplate template)
        {
            _repository.Entities.Update(template);
            await _repository.SaveChangesAsync();
        }
    }
}