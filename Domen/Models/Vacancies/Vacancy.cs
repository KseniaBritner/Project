using Domain.Models.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models.Vacanies
{
    public class Vacancy
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public VacancyWorkflow Workflow { get; private set; }
        
        public Candidate Create(CandidateDocument document, Guid? referralId)
        {
            return new Candidate(
                Guid.NewGuid(),
                Id,
                referralId,
                Workflow.Create(),
                document);
        }
    }
}
