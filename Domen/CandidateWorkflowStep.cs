namespace Domain
{
    public class CandidateWorkflowStep
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string Feedback { get; private set; }
       
        public void SetFeedback (string feedback)
        {
            Feedback = feedback;
        }

        public void Aprove (Guid userId, string feedback)
        {
            if (string.IsNullOrEmpty(feedback))
            {
                throw new ArgumentNullException(feedback);
            }

            Status = Status.Rejected;
            SetFeedback (feedback);
        }

        public void Restart()
        {
            Status = Status.Restarted;
        }
    }
}
