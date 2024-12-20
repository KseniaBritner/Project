using Domain.Models.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomen.VacanciesTests
{
    public class VacancyWorkflowStepTests
    {
        [Fact]
        public void Create_ValidStepNumber_ReturnsStep()
        {
            int stepNumber = 1;

            var step = VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), "description", stepNumber);

            Assert.NotNull(step);
            Assert.Equal(stepNumber, step.StepNumber);
        }
    }
}
