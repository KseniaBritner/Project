using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Candidates
{
    public class CandidateWorkflow
    {
        public CandidateWorkflow()
        { }

        public Status Status { get; private set; }
        public string Feedback { get; private set; }
        public IReadOnlyCollection<CandidateWorkflowStep> Steps { get; private set; }

        public void Approve(string feedback)
        {
            if (Steps.Select(step => step.Status).All(status => status == Status.Approved))
            {
                Status = Status.Approved;
            }
            else if (Steps.Any(workflowStep => workflowStep.Status == Status.Rejected))
            {
                Status = Status.Rejected;
            }

            Feedback = feedback;
        }

        public void Reject(string feedback)
        {
            Status = Status.Rejected;

            Feedback = feedback;
        }

        public void Restart()
        {
            foreach (var step in Steps)
            {
                step.Restart();
            }
            Status = Status.Restarted;
        }

    }

}
