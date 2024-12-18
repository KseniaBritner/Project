using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Candidates
{
    public class Candidate
    {
        public Candidate(Guid id,  
            Guid? referralId,  
            CandidateDocument document)
        {
            Id = id;
            ReferralId = referralId;
            Document = document;
        }

        public Guid Id { get; init; }
        public Guid VacancyId { get; private set; }
        public Guid? ReferralId { get; private set; }
        public CandidateWorkflow Workflow { get; private set; }
        public CandidateDocument Document { get; private set; }

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


