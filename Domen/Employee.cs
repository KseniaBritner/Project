using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {
        private Employee(Guid id,string name, Guid companyId, Guid roleId)
        {
            Id = id;
            Name = name;
            CompanyId = companyId;
            RoleId = roleId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        public Guid RoleId { get; set; }

        public static Employee Create(string name, Guid roleId, Guid companyId)
        {
            ArgumentNullException.ThrowIfNull(name);
            return new Employee(new Guid(), name, companyId, roleId);
        }
    }
}
