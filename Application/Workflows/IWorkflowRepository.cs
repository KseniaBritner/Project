using Application.Workflows.Entitys;
using Domain;

namespace Application.Workflows;

public interface IWorkflowRepository
{
    Task<IReadOnlyCollection<Workflow>> GetByUserId(Guid userId, bool isOpenOnly, CancellationToken cancellationToken);
    Task Create(Candidate candidate, CancellationToken cancellationToken);
}