using Domain.Candidates;
using Domain.Models.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomen.CandidatesTests
{
    public class CondidateT
    {
        [Fact]
        public void ValidCondidatETest()
        {
            var vacID=Guid.NewGuid();
            var refID=Guid.NewGuid();
            var doc = new CandidateDocument();
            var step = CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1);

            var workflow = CandidateWorkflow.Create(new[] { step });


        }
    }
}
