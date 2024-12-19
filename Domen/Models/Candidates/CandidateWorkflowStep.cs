using Domain.Models.Candidates;
using Domain.Models.Vacancies;
using System.Xml.Linq;

namespace Domain.Models.Candidates
{
    public class CandidateWorkflowStep
    {
        public CandidateWorkflowStep(Guid? userId, Guid? roleId, 
            string description, Status status, int stepNumber)
        {
            if (userId != null && roleId != null)
            {
                throw new ArgumentException("UserId и RoleId не могут быть указаны одновременно.");
            }

            UserId = userId;
            RoleId = roleId;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Status = status;
            StepNumber = stepNumber;
        }

        public Guid? UserId { get; private init; }
        public Guid? RoleId { get; private init; }
        public string Description { get; private set; }
        public Status Status { get; private set; }
        public string? Feedback { get; private set; }
        public int StepNumber { get; private set; }

        public static CandidateWorkflowStep Create(VacancyWorkflowStep vacancyWorkflowStep)
        {
            if (vacancyWorkflowStep.UserId != null && vacancyWorkflowStep.RoleId != null)
            {
                throw new ArgumentException("UserId и RoleId не могут быть указаны одновременно.");
            }
            
            return new CandidateWorkflowStep(vacancyWorkflowStep.UserId, vacancyWorkflowStep.RoleId, vacancyWorkflowStep.Description, Status.InProcessing, vacancyWorkflowStep.StepNumber);
        }

        public void Approve(Employee employee, string feedback)
        {
            ArgumentNullException.ThrowIfNull(nameof(employee));

            if (string.IsNullOrEmpty(feedback))
            {
                throw new ArgumentNullException(nameof(feedback));
            }

            Status = Status.Approved;
            Feedback = feedback;
        }

        public void Reject(Employee employee, string feedback)
        {
            ArgumentNullException.ThrowIfNull(nameof(employee));

            if (string.IsNullOrEmpty(feedback))
            {
                throw new ArgumentNullException(nameof(feedback));
            }

            Status = Status.Rejected;
            Feedback = feedback;
        }


        public void Restart()
        {
            Status = Status.Restarted;
            Feedback = null;
        }
    }
}
