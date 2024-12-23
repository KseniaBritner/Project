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
        public void Approve_ArgumentNullException_EmployeeIsNull()
        {
            var document = CreateCandidateDocument();
            var steps = new[] { CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1) };
            var workflow = CandidateWorkflow.Create(steps);
            var candidate = Candidate.Create(Guid.NewGuid(), null, document, workflow);

            Employee employee = null; 
            string feedback = "feedback";

            var exception = Assert.Throws<ArgumentNullException>(() => candidate.Approve(employee, feedback));
            Assert.StartsWith("������������ �� ����� ���� null.", exception.Message);
            Assert.Equal("employee", exception.ParamName);
        }

        [Fact]
        public void Approve_ThrowsArgumentException_WhenFeedbackIsNullOrWhiteSpace()
        {
            var document = CreateCandidateDocument();
            var steps = new[] { CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1) };
            var workflow = CandidateWorkflow.Create(steps);
            var candidate = Candidate.Create(Guid.NewGuid(), null, document, workflow);

            var employee = new Employee(Guid.NewGuid(), "John", Guid.NewGuid(), Guid.NewGuid());
            string feedback = " "; 

            var exception = Assert.Throws<ArgumentException>(() => candidate.Approve(employee, feedback));
            Assert.StartsWith("�������� ����� �� ����� ���� ������ ��� �������� �� ��������.", exception.Message);
            Assert.Equal("feedback", exception.ParamName);
        }


        private CandidateDocument CreateCandidateDocument()
        {
            var document = (CandidateDocument)Activator.CreateInstance(typeof(CandidateDocument), nonPublic: true);

            typeof(CandidateDocument).GetProperty("Name")!
                .SetValue(document, "Test");

            typeof(CandidateDocument).GetProperty("WorkExperience")!
                .SetValue(document, "3 years");

            return document;
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
