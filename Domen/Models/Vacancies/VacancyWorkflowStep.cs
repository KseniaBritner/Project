using Domain.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Vacancies;

public sealed class VacancyWorkflowStep
{
    private VacancyWorkflowStep(Guid? userId, Guid? roleId, string description, int stepNumber)
    {
        if (userId is null && roleId is null)
        {
            throw new ArgumentException("Either UserId or RoleId must be specified.");
        }

        ArgumentNullException.ThrowIfNull(description);

        UserId = userId;
        RoleId = roleId;
        Description = description;
        StepNumber = stepNumber;
    }

    public Guid? UserId { get; private init; }
    public Guid? RoleId { get; private init; }
    public string Description { get; private init; }
    public int StepNumber { get; private init; }

    public static VacancyWorkflowStep Create(Guid? userId, Guid? roleId, string description, int stepNumber)
        => new VacancyWorkflowStep(userId, roleId, description, stepNumber);

    public CandidateWorkflowStep ToCandidate()
        => CandidateWorkflowStep.Create(UserId, RoleId, StepNumber);
}

