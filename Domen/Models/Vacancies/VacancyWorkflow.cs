using Domain.Models.Candidates;
using Domain.Models.Vacancies;
using System.Collections.ObjectModel;

namespace Domain.Models.Vacanies
{
    public class VacancyWorkflow
    {
        public string Name { get; private set; }
        public IReadOnlyCollection<VacancyWorkflowStep> Steps { get; private set; }

        public VacancyWorkflow(string name, IReadOnlyCollection<VacancyWorkflowStep> steps)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Steps = steps ?? throw new ArgumentNullException(nameof(steps));
        }
        public CandidateWorkflow Create()
        {
            return CandidateWorkflow.Create(this);
        }
    }

}
