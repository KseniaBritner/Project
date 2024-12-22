using Domain.Candidates;
using Domain.Models.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomen.CandidatesTests
{
    public class CandidateWorkflowTest_Create
    {
        // Тест на передачу null в качестве параметра steps
        [Fact]
        public void Create_ThrowsArgumentException_WhenStepsIsNull()
        {
            IReadOnlyCollection<CandidateWorkflowStep> steps = null;

            var exception = Assert.Throws<ArgumentException>(() => CandidateWorkflow.Create(steps));
            Assert.StartsWith("Шаги рабочего процесса не могут быть пустыми.", exception.Message);
            Assert.Equal("steps", exception.ParamName);
        }

        // Тест на передачу пустой коллекции
        [Fact]
        public void Create_ThrowsArgumentException_WhenStepsIsEmpty()
        {
            var steps = new List<CandidateWorkflowStep>(); // Пустая коллекция

            var exception = Assert.Throws<ArgumentException>(() => CandidateWorkflow.Create(steps));
            Assert.StartsWith("Шаги рабочего процесса не могут быть пустыми.", exception.Message);
            Assert.Equal("steps", exception.ParamName);
        }
    }
}
