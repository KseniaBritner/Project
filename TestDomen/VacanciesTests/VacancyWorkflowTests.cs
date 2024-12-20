using Domain.Models.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomen.VacanciesTests
{
    public class VacancyWorkflowTests
    {
        [Fact]
        public void Create_ValidSteps_ReturnsVacancyWorkflow()
        {
            var steps = new List<VacancyWorkflowStep>
            {
                VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(),"description", 1),
                VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(),"description", 2)
            };

            var workflow = VacancyWorkflow.Create(steps);

            Assert.NotNull(workflow); 
            Assert.Equal(steps, workflow.Steps); 
        }

        [Fact]
        public void Create_NullSteps_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                VacancyWorkflow.Create(null));
        }

        [Fact]
        public void ToCandidate_ValidSteps_ReturnsCandidateWorkflow()
        {
            var steps = new List<VacancyWorkflowStep>
            {
                VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(),"description", 1),
                VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(),"description", 2)
            };
            var vacancyWorkflow = VacancyWorkflow.Create(steps);

            var candidateWorkflow = vacancyWorkflow.ToCandidate();

            Assert.NotNull(candidateWorkflow); 
            Assert.Equal(steps.Count, candidateWorkflow.Steps.Count); 
            Assert.All(candidateWorkflow.Steps, step => Assert.Contains(steps, s => s.StepNumber == step.Number)); // шаги корректные
        }
    }
}
