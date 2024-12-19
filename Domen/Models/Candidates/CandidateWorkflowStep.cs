using Domain.Models.Candidates;

namespace Domain.Models.Candidates
{
    public class CandidateWorkflowStep
    {
        public CandidateWorkflowStep(Guid? userId, Guid? roleId, 
            string description, Status status, string? feedback)
        {
            if (userId != null && roleId != null)
            {
                throw new ArgumentException("UserId и RoleId не могут быть указаны одновременно.");
            }

            UserId = userId;
            RoleId = roleId;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Status = status;
            Feedback = feedback;
        }

        public Guid? UserId { get; private set; }
        public Guid? RoleId { get; private set; }
        public string Description { get; init; }
        public Status Status { get; private set; }
        public string? Feedback { get; private set; }

        public static CandidateWorkflowStep Create(Guid? userId, Guid? roleId, string description)
        {
            if (userId != null && roleId != null)
            {
                throw new ArgumentException("UserId и RoleId не могут быть указаны одновременно.");
            }

            return new CandidateWorkflowStep(userId, roleId, description, Status.InProcessing, null);
        }

        public void Approve(Guid userId, string feedback)
        {
            if (string.IsNullOrEmpty(feedback))
            {
                throw new ArgumentNullException(nameof(feedback));
            }

            Status = Status.Approved;
            Feedback = feedback;
        }

        public void Restart()
        {
            Status = Status.Restarted;
        }
    }
}
