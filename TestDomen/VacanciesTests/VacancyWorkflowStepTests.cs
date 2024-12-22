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

        //проверки  userId и roleId на null
        [Fact]
        public void NullUserIdRoleId()
        {
            Guid? userId = null;
            Guid? roleId = null;
            string description = "Test";
            int stepNumber = 1;

            var exception = Assert.Throws<ArgumentException>(() => VacancyWorkflowStep.Create(userId, roleId, description, stepNumber));
            Assert.Equal("Должен быть указан либо UserId, либо RoleId.", exception.Message);
        }

        //проверки description на null
        [Fact]
        public void DescriptionIsNull()
        {
            Guid? userId = Guid.NewGuid();
            Guid? roleId = null;
            string description = null;
            int stepNumber = 1;

            Assert.Throws<ArgumentNullException>(() => VacancyWorkflowStep.Create(userId, roleId, description, stepNumber));
        }

        //проверки UserId на null
        [Fact]
        public void NullUserId()
        {
            Guid? userId = Guid.NewGuid();
            Guid? roleId = null;
            string description = "Test";
            int stepNumber = 1;

            var step = VacancyWorkflowStep.Create(userId, roleId, description, stepNumber);

            Assert.Equal(userId, step.UserId);
            Assert.Null(step.RoleId);
            Assert.Equal(description, step.Description);
            Assert.Equal(stepNumber, step.StepNumber);
        }

        //проверки RoleId на null
        [Fact]
        public void NullRoleId()
        {
            Guid? userId = null;
            Guid? roleId = Guid.NewGuid();
            string description = "Test";
            int stepNumber = 1;

            var step = VacancyWorkflowStep.Create(userId, roleId, description, stepNumber);

            Assert.Null(step.UserId);
            Assert.Equal(roleId, step.RoleId);
            Assert.Equal(description, step.Description);
            Assert.Equal(stepNumber, step.StepNumber);
        }
    }
}
