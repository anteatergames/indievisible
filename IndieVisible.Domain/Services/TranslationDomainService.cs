using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class TranslationDomainService : BaseDomainMongoService<TranslationProject, ITranslationRepository>, ITranslationDomainService
    {
        public TranslationDomainService(ITranslationRepository repository) : base(repository)
        {
        }
    }
}