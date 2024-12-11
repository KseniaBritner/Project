using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class Vacancy
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public VacancyWorkflow Workflow { get; set; }
    }
}
