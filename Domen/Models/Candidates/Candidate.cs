using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Candidates
{
    public class Candidate
    {
        public Candidate(Guid id, Guid vacancyId, Guid? referralId, 
            CandidateWorkflow workflow, CandidateDocument document)
        {
            Id = id;
            ReferralId = referralId;
            VacancyId = vacancyId;
            Workflow = workflow ?? throw new ArgumentNullException(nameof(workflow));
            Document = document ?? throw new ArgumentNullException(nameof(document));
        }

        public Guid Id { get; init; }
        public Guid VacancyId { get; private set; }
        public Guid? ReferralId { get; private set; }
        public CandidateWorkflow Workflow { get; private set; }
        public CandidateDocument Document { get; private set; }

        public static Candidate Create(CandidateDocument document, 
            Guid? referralId, CandidateWorkflow workflow)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            if (workflow == null) throw new ArgumentNullException(nameof(workflow));
            
            return new Candidate(Guid.NewGuid(), Guid.Empty, referralId, workflow, document);
        }
        public void Approve(string comment)
        {
            Workflow.Approve(comment);
        }

        public void Reject(string comment)
        {
            Workflow.Reject(comment);
        }

        public void Restart()
        {
            Workflow.Restart();
        }
    }
}


