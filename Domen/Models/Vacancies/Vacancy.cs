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

        public Vacancy(Guid id, string description, VacancyWorkflow workflow)
        {
            Id = id;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Workflow = workflow ?? throw new ArgumentNullException(nameof(workflow));
        }

        /*
          public Candidate Create(CandidateDocument document, Guid? referralId, Guid vacancyId)
        {
           return new Candidate(
                Guid.NewGuid(),
                vacancyId,
                referralId,
                new CandidateWorkflow(Workflow.Steps),
                document
                );
            
        }
        */
    }
}
