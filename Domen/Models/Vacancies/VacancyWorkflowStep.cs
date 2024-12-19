using Domain.Models.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Vacancies
{
    public class VacancyWorkflowStep
    {
        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }
        public string Description { get; private set; }

        public CandidateWorkflowStep Create()
        {
            return new CandidateWorkflowStep();
        }
    }

}
