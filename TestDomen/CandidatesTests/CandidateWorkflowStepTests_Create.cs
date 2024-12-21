using Xunit;
using Domain.Models.Candidates;
using Domain.Candidates;
using System;

namespace TestDomen.CandidatesTests
{

    public class CandidateWorkflowStepTests_Create
    {
        [Fact]
        public void Create_ValidParameters_ReturnsInstance()
        {
            Guid? employerId = Guid.NewGuid();
            Guid? roleId = Guid.NewGuid();
            int stepNumber = 1;

            var step = CandidateWorkflowStep.Create(employerId, roleId, stepNumber);

            Assert.NotNull(step);
            Assert.Equal(employerId, step.UserId);
            Assert.Equal(roleId, step.RoleId);
            Assert.Equal(stepNumber, step.Number);
            Assert.Equal(Status.InProcessing, step.Status);
        }
    }

}