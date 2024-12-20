using Domain.Candidates;
using Domain.Models;
using Domain.Models.Candidates;
using Domain.Models.Vacancies;
using Xunit;

namespace TestDomen.VacanciesTests
{
    public class VacancyTests
    {
        [Fact]
        public void Create_ValidParameters_ReturnsVacancy()
        {
            var companyId = Guid.NewGuid(); 
            var description = "Требуется разработчик для работы в DEX";
            var step = VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(),description, 1);
            var workflow = VacancyWorkflow.Create(new[] { step }); 

            var vacancy = Vacancy.Create(companyId, description, workflow); 

            Assert.NotNull(vacancy);
            Assert.Equal(companyId, vacancy.CompanyId); 
            Assert.Equal(description, vacancy.Description); 
            Assert.Equal(workflow, vacancy.Workflow); 
        }

        [Fact]
        public void Create_NullDescription_ThrowsException()
        {
            var companyId = Guid.NewGuid();
            var step = VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), "ok", 1);
            var workflow = VacancyWorkflow.Create(new[] { step });

            Assert.Throws<ArgumentNullException>(() =>
                Vacancy.Create(companyId, null, workflow));
        }

        [Fact]
        public void Create_NullWorkflow_ThrowsException()
        {
            var companyId = Guid.NewGuid();
            var description = "Описание вакансии";

            Assert.Throws<ArgumentNullException>(() =>
                Vacancy.Create(companyId, description, null));
        }

        [Fact]
        public void CreateCandidate_ValidParameters_ReturnsCandidate()
        {
            var companyId = Guid.NewGuid(); 
            var description = "Описание вакансии";
            var step = VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), description, 1);
            var workflow = VacancyWorkflow.Create(new[] { step });
            var candidateDocument = new CandidateDocument(); 
            var referralId = Guid.NewGuid(); 

            var vacancy = Vacancy.Create(companyId, description, workflow); 

            var candidate = vacancy.CreateCandidate(candidateDocument, referralId); 

            Assert.NotNull(candidate);
            Assert.Equal(vacancy.Id, candidate.VacancyId); 
            Assert.Equal(candidateDocument, candidate.Document); 
            Assert.Equal(referralId, candidate.ReferralId); 
        }

        [Fact]
        public void CreateCandidate_NullDocument_ThrowsException()
        {
            var companyId = Guid.NewGuid();
            var description = "Описание вакансии";
            var step = VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), description, 1);
            var workflow = VacancyWorkflow.Create(new[] { step });

            var vacancy = Vacancy.Create(companyId, description, workflow);

            Assert.Throws<ArgumentNullException>(() =>
                vacancy.CreateCandidate(null, Guid.NewGuid()));
        }
    }
}
