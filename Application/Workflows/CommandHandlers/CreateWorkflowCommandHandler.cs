using Application.Core;
using Application.Workflows.Commands;
using Application.Workflows.Entitys;
using Application.WTs;
using Domain;

namespace Application.Workflows.CommandHandlers;

public class CreateWorkflowCommandHandler : IRequestHandler<CreateWorkflowCommand, Guid>
{
    private readonly IWorkflowRepository _workflowRepository;
    private readonly IWTR _workflowTemplateRepository;

    public CreateWorkflowCommandHandler(IWTR workflowTemplateRepository, IWorkflowRepository workflowRepository)
    {
        _workflowTemplateRepository = workflowTemplateRepository ?? throw new ArgumentNullException(nameof(workflowTemplateRepository));
        _workflowRepository = workflowRepository ?? throw new ArgumentNullException(nameof(workflowRepository));
    }

    public async Task<Guid> Handle(CreateWorkflowCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var workflowTemplate = await _workflowTemplateRepository.GetById(request.WTID, cancellationToken).ConfigureAwait(false);
        if (workflowTemplate == null) throw new InvalidOperationException("Workflow template not found.");

        var workflow = workflowTemplate.CreateWorkflow(request.UserReferaleId);
        var candidate = new Candidate(workflow, request.Document);

        await _workflowRepository.Create(candidate, cancellationToken).ConfigureAwait(false);

        return candidate.Id;
    }
}
