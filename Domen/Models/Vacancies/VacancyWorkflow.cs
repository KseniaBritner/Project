using Domain.Enum;
using Domain.Models.Candidates;
using Domain.Models.Vacancies;
using System.Collections.ObjectModel;

namespace Domain.Models.Vacanies
{
    public class VacancyWorkflow
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<VacancyWorkflowStep> Steps { get; private set; }

        public CandidateWorkflow Create()
        {
            return new CandidateWorkflow();
        }
    }

}
