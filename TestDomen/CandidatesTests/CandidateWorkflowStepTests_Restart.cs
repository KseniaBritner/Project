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
    public class CandidateWorkflowStepTests_Restart
    {
        // метод Restart сбрасывает свойства шага
        [Fact]
        public void Restart_Step()
        {
            var employee = new Employee(Guid.NewGuid(), "John", Guid.NewGuid(), Guid.NewGuid());
            var step = CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 1);

            step.Reject(employee, "Не подходит");

            step.Restart();

            Assert.Equal(Status.InProcessing, step.Status);
            Assert.Null(step.Feedback);
            Assert.Null(step.FeedbackDate);
        }

        //  метод Restart устанавливает статус на InProcessing, если статус был Rejected
        [Fact]
        public void Restart_StatusToInProcessing_StatusRejected()
        {
            var employee = new Employee(Guid.NewGuid(), "John Doe", Guid.NewGuid(), Guid.NewGuid());
            var step = CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 1);

            step.Reject(employee, "feedback");

            step.Restart();

            Assert.Equal(Status.InProcessing, step.Status);
        }
    }
}
