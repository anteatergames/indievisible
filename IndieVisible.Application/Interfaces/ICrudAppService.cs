using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface ICrudAppService<T>
    {
        Guid CurrentUserId { get; set; }

        OperationResultVo<int> Count();
        OperationResultListVo<T> GetAll(Guid currentUserId);
        OperationResultVo<T> GetById(Guid currentUserId, Guid id);
        OperationResultVo<Guid> Save(T viewModel);
        OperationResultVo Remove(Guid id);
    }
}
