using Domain.Models;
using Domain.Models.Candidates;
using Domain.Models.Vacancies;
using System.Xml.Linq;

namespace Domain.Candidates;

public sealed class CandidateWorkflowStep
{
    private CandidateWorkflowStep(
        Guid? userId,
        Guid? roleId,
        int number,
        Status status,
        string? feedback,
        DateTime? feedbackDate)
    {
        if (userId is null && roleId is null)
        {
            throw new ArgumentException("Должен быть указан хотя бы один из параметров: userId или roleId.");
        }

        UserId = userId;
        RoleId = roleId;
        Number = number;
        Status = status;
        Feedback = feedback;
        FeedbackDate = feedbackDate;
    }

    public Guid? UserId { get; private init; }
    public Guid? RoleId { get; private init; }
    public int Number { get; private init; }
    public Status Status { get; private set; }
    public string? Feedback { get; private set; }
    public DateTime? FeedbackDate { get; private set; }

    public static CandidateWorkflowStep Create(Guid? userId, Guid? roleId, int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Номер шага должен быть больше нуля.");
        }

        return new CandidateWorkflowStep(
            userId,
            roleId,
            number,
            Status.InProcessing,
            feedback: null,
            feedbackDate: null);
    }

    internal void Approve(Employee employee, string feedback)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee), "Пользователь не может быть null.");
        }

        if (string.IsNullOrWhiteSpace(feedback))
        {
            throw new ArgumentException("Обратная связь не может быть пустой или состоять из пробелов.", nameof(feedback));
        }

        ValidateStatusChange(employee);

        Status = Status.Approved;
        Feedback = feedback;
        FeedbackDate = DateTime.UtcNow;
    }

    internal void Reject(Employee employee, string feedback)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee), "Пользователь не может быть null.");
        }

        if (string.IsNullOrWhiteSpace(feedback))
        {
            throw new ArgumentException("Обратная связь не может быть пустой или состоять из пробелов.", nameof(feedback));
        }

        ValidateStatusChange(employee);

        Status = Status.Rejected;
        Feedback = feedback;
        FeedbackDate = DateTime.UtcNow;
    }

    internal void Restart()
    {
        Status = Status.InProcessing;
        Feedback = null;
        FeedbackDate = null;
    }

    private void ValidateStatusChange(Employee employee)
    {
        if (Status != Status.InProcessing)
        {
            throw new InvalidOperationException("Статус может быть изменён только, если он находится в обработке.");
        }

        if (employee.Id != UserId && employee.RoleId != RoleId)
        {
            throw new UnauthorizedAccessException("Пользователь не имеет прав на изменение статуса этого шага.");
        }
    }
}
