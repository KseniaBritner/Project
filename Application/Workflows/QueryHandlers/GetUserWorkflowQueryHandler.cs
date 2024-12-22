using Application.Core;
using Application.Workflows.Entitys;
using Application.Workflows.Queries;

namespace Application.Workflows.QueryHandlers;

public class GetUserWorkflowsQueryHandler : IRequestHandler<GetUserWorkflowsQuery, IReadOnlyCollection<Workflow>>
{
    private readonly IWorkflowRepository _workflowRepository;

    public GetUserWorkflowsQueryHandler(IWorkflowRepository workflowRepository)
    {
        _workflowRepository = workflowRepository ?? throw new ArgumentNullException(nameof(workflowRepository));
    }

    public async Task<IReadOnlyCollection<Workflow>> Handle(GetUserWorkflowsQuery request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        return await _workflowRepository.GetByUserId(request.UserId, request.IsOpenOnly, cancellationToken).ConfigureAwait(false);
    }
}

