using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Candidates;

namespace Domain.Models.Candidates;

public sealed class Candidate
{
    public Candidate(Guid id, Guid vacancyId, Guid? referralId, CandidateDocument document, CandidateWorkflow workflow)
    {
        ArgumentNullException.ThrowIfNull(document, nameof(document));
        ArgumentNullException.ThrowIfNull(workflow, nameof(workflow));

        Id = id;
        VacancyId = vacancyId;
        ReferralId = referralId;
        Workflow = workflow;
        Document = document;
    }

    public Guid Id { get; private init; }
    public Guid VacancyId { get; private init; }
    public Guid? ReferralId { get; private init; }
    public CandidateDocument Document { get; private init; }
    public CandidateWorkflow Workflow { get; private init; }
    public Status Status => Workflow.Status;

    public static Candidate Create(
        Guid vacancyId,
        Guid? referralId,
        CandidateDocument document,
        CandidateWorkflow workflow)
        => new(Guid.NewGuid(), vacancyId, referralId, document, workflow);

    public void Approve(Employee employee, string feedback)
        => Workflow.Approve(employee, feedback);

    public void Reject(Employee employee, string feedback)
        => Workflow.Reject(employee, feedback);

    public void Restart()
        => Workflow.Restart();
}




