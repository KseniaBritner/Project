using Domain.Models;
using Domain.Candidates;
using Domain.Models.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.Candidates;

public sealed class CandidateWorkflow
{
    private CandidateWorkflow(IReadOnlyCollection<CandidateWorkflowStep> steps)
    {
        if (steps == null || !steps.Any())
        {
            throw new ArgumentException("Шаги рабочего процесса не могут быть пустыми.", nameof(steps));
        }

        Steps = steps;
    }

    public IReadOnlyCollection<CandidateWorkflowStep> Steps { get; private set; }
    internal Status Status => GetStatus();

    public static CandidateWorkflow Create(IReadOnlyCollection<CandidateWorkflowStep> steps)
    {
        if (steps == null || !steps.Any())
        {
            throw new ArgumentException("Для создания рабочего процесса должны быть указаны шаги.", nameof(steps));
        }

        return new CandidateWorkflow(steps);
    }

    public void Approve(Employee employee, string feedback)
    {
        GetCurrentInProcessingStep().Approve(employee, feedback);
    }

    public void Reject(Employee employee, string feedback)
    {
        GetCurrentInProcessingStep().Reject(employee, feedback);
    }

    public void Restart()
    {
        foreach (var step in Steps)
        {
            step.Restart();
        }
    }

    private CandidateWorkflowStep GetCurrentInProcessingStep()
    {
        var status = GetStatus();

        if (status == Status.Approved)
        {
            throw new InvalidOperationException("Невозможно выполнить операцию: рабочий процесс уже утвержден.");
        }

        if (status == Status.Rejected)
        {
            throw new InvalidOperationException("Невозможно выполнить операцию: рабочий процесс отклонен.");
        }

        var currentStep = Steps
            .Where(step => step.Status == Status.InProcessing)
            .OrderBy(step => step.Number)
            .FirstOrDefault();

        if (currentStep == null)
        {
            throw new InvalidOperationException("Текущий шаг с состоянием 'В процессе' не найден.");
        }

        return currentStep;
    }

    private Status GetStatus()
    {
        if (Steps.All(step => step.Status == Status.Approved))
        {
            return Status.Approved;
        }

        if (Steps.Any(step => step.Status == Status.Rejected))
        {
            return Status.Rejected;
        }

        return Status.InProcessing;
    }
}

