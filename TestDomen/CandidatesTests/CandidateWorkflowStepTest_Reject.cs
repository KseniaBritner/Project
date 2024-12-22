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
    public class CandidateWorkflowStepTest_Reject
    {
        // метод Reject устанавливает статус шага на Rejected
        [Fact]
        public void Reject_StatusToRejected()
        {
            var employee = new Employee(Guid.NewGuid(), "John", Guid.NewGuid(), Guid.NewGuid());
            var step = CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 1);

            step.Reject(employee, "Не подходит");

            Assert.Equal(Status.Rejected, step.Status);
            Assert.Equal("Не подходит", step.Feedback);
            Assert.NotNull(step.FeedbackDate);
        }

        // если сотрудник равен null
        [Fact]
        public void Reject_EmployeeIsNull()
        {
            var step = CandidateWorkflowStep.Create(userId: Guid.NewGuid(), roleId: null, number: 1);

            var exception = Assert.Throws<ArgumentNullException>(() => step.Reject(null, "feedback"));
            Assert.StartsWith("Пользователь не может быть null.", exception.Message);
            Assert.Equal("employee", exception.ParamName);
        }

        // если feedback равен null
        [Fact]
        public void Reject_FeedbackIsNull()
        {
            var employee = new Employee(Guid.NewGuid(), "John", Guid.NewGuid(), Guid.NewGuid());
            var step = CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 1);

            var exception = Assert.Throws<ArgumentException>(() => step.Reject(employee, null));
            Assert.StartsWith("Обратная связь не может быть пустой или состоять из пробелов.", exception.Message);
            Assert.Equal("feedback", exception.ParamName);
        }


    }
}
