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
    public class CandidateWorkflowTests_Approve
    {
        [Fact]
        public void Approve_ValidEmployee_ChangesStatusToApproved()
        {
            var employee = new Employee(Guid.NewGuid(), "Иванов В.В.", Guid.NewGuid(), Guid.NewGuid());

            var step = CandidateWorkflowStep.Create(employee.Id, employee.RoleId, 1);
            var workflow = CandidateWorkflow.Create(new[] { step });

         
            workflow.Approve(employee, "Approved");

            Assert.Equal(Status.Approved, step.Status);
            Assert.Equal("Approved", step.Feedback);
        }

        [Fact]
        public void Approve_InvalidEmployee_ThrowsException()
        {
            var validEmployee = new Employee(Guid.NewGuid(), "Иванов В.В. (допустимый)", Guid.NewGuid(), Guid.NewGuid());
            var invalidEmployee = new Employee(Guid.NewGuid(), "Соколов С.С. (недопустимый)", Guid.NewGuid(), Guid.NewGuid());

            var step = CandidateWorkflowStep.Create(validEmployee.Id, validEmployee.RoleId, 1);
            var workflow = CandidateWorkflow.Create(new[] { step });

            Assert.Throws<UnauthorizedAccessException>(() => workflow.Approve(invalidEmployee, "Approved"));
        }
    }
}
