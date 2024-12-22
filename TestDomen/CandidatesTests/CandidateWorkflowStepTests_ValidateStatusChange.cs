using Domain.Candidates;
using Domain.Models.Candidates;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomen.CandidatesTests
{
    public class CandidateWorkflowStepTests_ValidateStatusChange
    {
        // если статус не "InProcessing"
        [Fact]
        public void ValidateStatusChange_StatusIsNotInProcessing()
        {
            var employee = new Employee(Guid.NewGuid(), "John", Guid.NewGuid(), Guid.NewGuid());
            var step = CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 1);

            step.GetType().GetProperty("Status")?.SetValue(step, Status.Approved);

            var exception = Assert.Throws<InvalidOperationException>(() => step.Approve(employee, "feedback"));
            Assert.Equal("Статус может быть изменён только, если он находится в обработке.", exception.Message);
        }

    }
}
