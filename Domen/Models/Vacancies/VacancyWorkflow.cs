using Domain.Models.Candidates;
using Domain.Models.Vacancies;
using System.Collections.ObjectModel;

namespace Domain.Models.Vacancies;

public sealed class VacancyWorkflow
{
    private VacancyWorkflow(IReadOnlyCollection<VacancyWorkflowStep> steps)
    {
        Steps = steps ?? throw new ArgumentNullException(nameof(steps));
    }

    public IReadOnlyCollection<VacancyWorkflowStep> Steps { get; private init; }

    public static VacancyWorkflow Create(IReadOnlyCollection<VacancyWorkflowStep> steps)
        => new VacancyWorkflow(steps);

    public CandidateWorkflow ToCandidate()
        => CandidateWorkflow.Create(Steps.Select(step => step.ToCandidate()).ToArray());
}
