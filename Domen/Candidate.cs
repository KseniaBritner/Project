using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Candidate
    {
        public Guid Id { get; init; }
        public Guid VacancyId { get; set; }
        public Guid? ReferralId { get; set; }
        public CandidateWorkflow Workflow { get; set; }
        public CandidateDocument Document { get; set; }

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


