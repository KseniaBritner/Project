using Application.Core;
using Application.Workflows.Entitys;

namespace Application.Workflows.Commands;

public class CreateWorkflowCommand : IRequest<Guid>
{
    public CreateWorkflowCommand(Guid userReferaleId, Document document, Guid wtId)
    {
        UserReferaleId = userReferaleId;
        Document = document;
        WTID = wtId;
    }

    public Guid UserReferaleId { get; }
    public Document Document { get; }
    public Guid WTID { get; }
}
