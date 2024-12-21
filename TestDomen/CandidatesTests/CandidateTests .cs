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
        public void Approve_ValidEmployee_UpdatesStatus()
        {
            var employee = new Employee(Guid.NewGuid(), "Иванов В.В.", Guid.NewGuid(), Guid.NewGuid());
            var step = CandidateWorkflowStep.Create(employee.Id, employee.RoleId, 1);
            var workflow = CandidateWorkflow.Create(new[] { step });
            var candidate = Candidate.Create(Guid.NewGuid(), null, new CandidateDocument(), workflow);

            candidate.Approve(employee, "Approved");

            Assert.Equal(Status.Approved, candidate.Status);
        }

       

    }
}
