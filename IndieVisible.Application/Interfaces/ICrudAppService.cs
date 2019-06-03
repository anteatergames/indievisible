using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndieVisible.Application.Interfaces
{
    public interface ICrudAppService<T>
    {
        Guid CurrentUserId { get; set; }

        OperationResultVo<int> Count();
        OperationResultListVo<T> GetAll();
        OperationResultVo<T> GetById(Guid id);
        OperationResultVo<Guid> Save(T viewModel);
        OperationResultVo Remove(Guid id);
    }
}
