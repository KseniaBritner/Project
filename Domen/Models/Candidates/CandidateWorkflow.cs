using Domain.Models.Candidates;
using Domain.Models.Vacanies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Candidates
{
    public class CandidateWorkflow
    {
        public CandidateWorkflow(Status status, 
            IReadOnlyCollection<CandidateWorkflowStep> steps)
        {
            Status = status;
            Steps = steps ?? throw new ArgumentNullException(nameof(steps));
        }
        
        public Status Status { get; private set; }
        public string? Feedback { get; private set; }
        public IReadOnlyCollection<CandidateWorkflowStep> Steps { get; init; }

        public static CandidateWorkflow Create(VacancyWorkflow vacancyWorkflow)
        {
            return new CandidateWorkflow(Status.InProcessing, new List<CandidateWorkflowStep>(vacancyWorkflow.Steps.Select(CandidateWorkflowStep.Create)));
        }

        public void Approve(Employee employee, string feedback)
        {
            ArgumentNullException.ThrowIfNull(employee, nameof(employee));
            ArgumentNullException.ThrowIfNull(feedback, nameof(feedback));

            if (Steps.Select(step => step.Status).All(status => status == Status.Approved))
            {
                Status = Status.Approved;
            }
            else if (Steps.Any(workflowStep => workflowStep.Status == Status.Rejected))
            {
                Status = Status.Rejected;
            }

            var stepInProgress = Steps.OrderBy(step => step.StepNumber).SingleOrDefault();

            ArgumentNullException.ThrowIfNull(stepInProgress);

            stepInProgress.Approve(employee, feedback);

        }

        public void Reject(Employee employee, string feedback)
        {
            var stepInProgress = Steps.OrderBy(step => step.StepNumber).SingleOrDefault();

            ArgumentNullException.ThrowIfNull(stepInProgress);

            stepInProgress.Reject(employee, feedback);
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
