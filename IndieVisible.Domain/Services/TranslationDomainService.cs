using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Services
{
    public class TranslationDomainService : BaseDomainMongoService<TranslationProject, ITranslationRepository>, ITranslationDomainService
    {
        public TranslationDomainService(ITranslationRepository repository) : base(repository)
        {
        }

        public TranslationProject GenerateNewProject(Guid currentUserId)
        {
            TranslationProject model = new TranslationProject();

            return model;
        }
    }
}