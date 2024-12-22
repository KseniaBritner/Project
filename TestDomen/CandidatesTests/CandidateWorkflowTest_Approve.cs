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
    public class CandidateWorkflowTest_Approve
    {
        //Approve (отриц.сценарии employee)
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

        //Approve (отриц.сценарии feedback)
        [Fact]
        public void Approve_ThrowArgumentException_FeedbackIsInvalid()
        {
            var steps = new[] { CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1) };
            var workflow = CandidateWorkflow.Create(steps);
            var employee = new Employee(Guid.NewGuid(), "Employee", Guid.NewGuid(), Guid.NewGuid());
            string feedback = "";

            var exception = Assert.Throws<ArgumentException>(() => workflow.Approve(employee, feedback));
            Assert.StartsWith("Обратная связь не может быть пустой или состоять из пробелов.", exception.Message);
            Assert.Equal("feedback", exception.ParamName);
        }
    }
}
