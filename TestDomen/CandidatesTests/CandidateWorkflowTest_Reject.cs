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
    public class CandidateWorkflowTest_Reject
    {
        // метод Reject устанавливает статус шага на Rejected
        [Fact]
        public void Reject_StatusToRejected()
        {
            var employee = new Employee(Guid.NewGuid(), "John", Guid.NewGuid(), Guid.NewGuid());
            var steps = new List<CandidateWorkflowStep>
            {
                CandidateWorkflowStep.Create(userId: employee.Id, roleId: null, number: 1)
            };

            var workflow = CandidateWorkflow.Create(steps);

            workflow.Reject(employee, "Не подходит");

            Assert.All(workflow.Steps, step => Assert.Equal(Status.Rejected, step.Status));
        }
    }
}
