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
    public class CandidateWorkflowTest_Restart
    {
        // метод Restart устанавливает статус всех шагов на InProcessing
        [Fact]
        public void Restart_StepsToInProcessing()
        {
            var employee = new Employee(Guid.NewGuid(), "John", Guid.NewGuid(), Guid.NewGuid());
            var steps = new List<CandidateWorkflowStep>
            {
                CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 1),
                CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 2)
            };

            var workflow = CandidateWorkflow.Create(steps);

            workflow.Restart();

            Assert.All(workflow.Steps, step => Assert.Equal(Status.InProcessing, step.Status));
        }

        //метод Restart сбрасывает feedback и feedbackDate для всех шагов
        [Fact]
        public void Restart_FeedbackAndFeedbackDate()
        {
            var employee = new Employee(Guid.NewGuid(), "John", Guid.NewGuid(), Guid.NewGuid());
            var steps = new List<CandidateWorkflowStep>
            {
                CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 1)
            };

            var workflow = CandidateWorkflow.Create(steps);

            workflow.Reject(employee, "Не подходит");

            workflow.Restart();

            foreach (var step in workflow.Steps)
            {
                Assert.Null(step.Feedback);
                Assert.Null(step.FeedbackDate);
            }
        }
    }
}
