using Application.Core;
using Application.Workflows.Entitys;

namespace Application.Workflows.Queries;

public class GetUserWorkflowsQuery : IRequest<IReadOnlyCollection<Workflow>>
{
    public GetUserWorkflowsQuery(Guid userId, bool isOpenOnly)
    {
        UserId = userId;
        IsOpenOnly = isOpenOnly;
    }

    public Guid UserId { get; private set; }
    public bool IsOpenOnly { get; private set; }
}
