using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CandidateWorkflow
    {
        public Status Status { get; set; }
        public string Feedback { get; set; }
        public ICollection<CandidateWorkflowStep> Steps { get; set; }

        public void SetFeedback(string feedback)
        {
            Feedback = feedback;
        }

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

            SetFeedback(feedback);
        }

        public void Reject(string feedback)
        {
            Status = Status.Rejected;

            SetFeedback(feedback);
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
