using Domain.Models.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomen.VacanciesTests
{
    public class VacancyWorkflowStepTests_Create
    {
        //проверка метода Create на отриц. шаг
        [Fact]
        public void Create_NegativeStepNumber()
        {
            Guid? userId = Guid.NewGuid();
            Guid? roleId = Guid.NewGuid();
            string description = "Test";
            int negativeStepNumber = -1;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => VacancyWorkflowStep.Create(userId, roleId, description, negativeStepNumber));
            Assert.Equal("stepNumber", exception.ParamName);
        }
    }
}
