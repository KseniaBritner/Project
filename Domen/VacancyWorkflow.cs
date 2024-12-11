namespace Domain
{
    public class VacancyWorkflow
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<VacancyWorkflowStep> Steps { get; set; }

        public CandidateWorkflow Create()
        {
            return new CandidateWorkflow
            {
                Steps = Steps.Select(step => step.Create()).ToList(),
                Status = Status.InProcessing
            };
        }
    }

}
