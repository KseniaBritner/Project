using Domain.Candidates;
using Domain.Models;
using Domain.Models.Candidates;
using Xunit;


namespace TestDomen.CandidatesTests
{
    public class CandidateTests
    {
        [Fact]
        public void Create_ValidParameters_ReturnsCandidate()
        {
            var vacancyId = Guid.NewGuid();
            var referralId = Guid.NewGuid();
            var document = new CandidateDocument();
            var step = CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1);
            var workflow = CandidateWorkflow.Create(new[] { step });

            var candidate = Candidate.Create(vacancyId, referralId, document, workflow);

            Assert.NotNull(candidate);
            Assert.Equal(vacancyId, candidate.VacancyId);
            Assert.Equal(referralId, candidate.ReferralId);
            Assert.Equal(document, candidate.Document);
            Assert.Equal(Status.InProcessing, candidate.Status);
        }

        [Fact]
        public void Approve_ThrowArgumentNullException_EmployeeIsNull()
        {
            var steps = new[] { CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1) };
            var workflow = CandidateWorkflow.Create(steps);
            Employee employee = null;
            string feedback = "feedback";

            var exception = Assert.Throws<ArgumentNullException>(() => workflow.Approve(employee, feedback));
            Assert.StartsWith("Пользователь не может быть null.", exception.Message);
            Assert.Equal("employee", exception.ParamName);
        }

        [Fact]
        public void Approve_ThrowArgumentException_FeedbackIsEmpty()
        {
            var steps = new[] { CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1) };
            var workflow = CandidateWorkflow.Create(steps);
            var employee = new Employee(Guid.NewGuid(), "Employee", Guid.NewGuid(), Guid.NewGuid());
            string feedback = "";  

            var exception = Assert.Throws<ArgumentException>(() => workflow.Approve(employee, feedback));
            Assert.StartsWith("Обратная связь не может быть пустой или состоять из пробелов.", exception.Message);
            Assert.Equal("feedback", exception.ParamName);
        }


        [Fact]
        public void Restart_ShouldInvokeWorkflowRestart()
        {
            var steps = new[] { CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1) };
            var workflow = CandidateWorkflow.Create(steps);
            var candidate = Candidate.Create(Guid.NewGuid(), null, new CandidateDocument(), workflow);

            var exception = Record.Exception(() => candidate.Restart());

            Assert.Null(exception);
        }

    }
}
