using Domain.Candidates;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomen.CandidatesTests
{
    public class CandidateWorkflowStepTest_Approve
    {
        // если сотрудник равен null
        [Fact]
        public void Approve_ShouldThrowException_EmployeeIsNull()
        {
            var step = CandidateWorkflowStep.Create(userId: Guid.NewGuid(), roleId: null, number: 1);

            var exception = Assert.Throws<ArgumentNullException>(() => step.Approve(null, "feedback"));
            Assert.StartsWith("Пользователь не может быть null.", exception.Message);
            Assert.Equal("employee", exception.ParamName);
        }

        //если feedback равен null
        [Fact]
        public void Approve_ShouldThrowException_FeedbackIsNull()
        {
            var employee = new Employee(Guid.NewGuid(), "John", Guid.NewGuid(), Guid.NewGuid());
            var step = CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 1);

            var exception = Assert.Throws<ArgumentException>(() => step.Approve(employee, null));
            Assert.StartsWith("Обратная связь не может быть пустой или состоять из пробелов.", exception.Message);
            Assert.Equal("feedback", exception.ParamName);
        }
    }
}
