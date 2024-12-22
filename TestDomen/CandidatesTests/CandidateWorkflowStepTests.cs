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
    public class CandidateWorkflowStepTests
    {
        [Fact] // отрицательный шаг
        public void NumberZero_ArgumentOutOfRangeException()
        {
            int invalidNumber = -1; 

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), invalidNumber));
            Assert.StartsWith("Номер шага должен быть больше нуля.", exception.Message);
            Assert.Equal("number", exception.ParamName); 
        }

        // если number > 0
        [Fact]
        public void NumberZero_ThrowException()
        {
            int validNumber = 1; 

            var step = CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), validNumber); 
            Assert.NotNull(step); 
        }

        //  если оба параметра равны null
        [Fact]
        public void UserIdAndRoleIdNull()
        {
            Guid? userId = null;
            Guid? roleId = null;

            var exception = Assert.Throws<ArgumentException>(() => CandidateWorkflowStep.Create(userId, roleId, 1)); 
            Assert.Equal("Должен быть указан хотя бы один из параметров: userId или roleId.", exception.Message);
        }

        // если хотя бы один параметр не null
        [Fact]
        public void UserIdNull()
        {
            Guid? userId = Guid.NewGuid();
            Guid? roleId = null;

            var step = CandidateWorkflowStep.Create(userId, roleId, 1); 
            Assert.NotNull(step);
        }

        [Fact]
        public void RoleIdNotNull()
        {
            Guid? userId = null;
            Guid? roleId = Guid.NewGuid();

            var step = CandidateWorkflowStep.Create(userId, roleId, 1); 
            Assert.NotNull(step);
        }
    }
}
