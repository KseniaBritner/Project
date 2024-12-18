using Domain.Enum;

namespace Domain.Models.Candidates
{
    public class CandidateWorkflowStep
    {
        public CandidateWorkflowStep(Guid userId, 
            Guid roleId, 
            string description, 
            Status status)
        {
            UserId = userId;
            RoleId = roleId;
            Description = description;
            Status = status;
        }

        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }
        public string Description { get; private set; }
        public Status Status { get; private set; }
        public string Feedback { get; private set; }

        public void SetFeedback(string feedback)
        {
            Feedback = feedback;
        }

        public void Approve(Guid userId, string feedback)
        {
            if (string.IsNullOrEmpty(feedback))
            {
                throw new ArgumentNullException(feedback);
            }

            Status = Status.Approved;
            SetFeedback(feedback);
        }

        public void Restart()
        {
            Status = Status.Restarted;
        }
    }
}
