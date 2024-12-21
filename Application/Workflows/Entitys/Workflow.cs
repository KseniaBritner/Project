namespace Application.Workflows.Entitys;

public class Workflow
{
    public Workflow(Guid id, IReadOnlyCollection<Step> steps, DateTime createdAt, Candidate candidate)
    {
        Id = id;
        Steps = steps;
        CreatedAt = createdAt;
        Candidate = candidate;
    }

    public Guid Id { get; }
    public IReadOnlyCollection<Step> Steps { get; }
    public DateTime CreatedAt { get; }
    public Candidate Candidate { get; }
}
