﻿using Domain.Candidates;
using Domain.Models.Candidates;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Reflection;

namespace TestDomen.CandidatesTests
{

    public class CandidateWorkflowTest
    {
        //если передан null
        [Fact]
        public void StepsIsNull_ThrowsArgumentException()
        {
            IReadOnlyCollection<CandidateWorkflowStep> steps = null;

            var exception = Assert.Throws<ArgumentException>(() => CandidateWorkflow.Create(steps));
            
            Assert.StartsWith("Шаги рабочего процесса не могут быть пустыми.", exception.Message);
            Assert.Equal("steps", exception.ParamName);
        }

        // коллекция шагов пуста
        [Fact]
        public void StepsIsEmpty_ThrowsArgumentException()
        {
            var steps = new List<CandidateWorkflowStep>();

            var exception = Assert.Throws<ArgumentException>(() => CandidateWorkflow.Create(steps));
           
            Assert.StartsWith("Шаги рабочего процесса не могут быть пустыми.", exception.Message);
            Assert.Equal("steps", exception.ParamName);
        }

        // если steps содержит элементы
        [Fact]
        public void StepsIsNotEmpty_NotThrowException()
        {
            var steps = new List<CandidateWorkflowStep>
            {
            CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1)
            };

            var workflow = CandidateWorkflow.Create(steps); 
            Assert.NotNull(workflow); 
        }

    }
}
