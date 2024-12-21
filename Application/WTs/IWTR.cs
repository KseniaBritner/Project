using Domain;

namespace Application.WTs;

public interface IWTR
{
    Task<WorkflowTemplate> GetById(Guid id, CancellationToken cancellationToken);
}
