using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee
    {
        public Employee(Guid id, string name, Guid companyId, Guid roleId)
        {
            Id = id;
            Name = name;
            CompanyId = companyId;
            RoleId = roleId;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid CompanyId { get; private set; }
        public Guid RoleId { get; private set; }

        public static Employee Create(string name, Guid roleId, Guid companyId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не может быть пустым или состоять только из пробелов.", nameof(name));
            }

            if (roleId == Guid.Empty)
            {
                throw new ArgumentException("RoleId не может быть пустым.", nameof(roleId));
            }

            if (companyId == Guid.Empty)
            {
                throw new ArgumentException("CompanyId не может быть пустым.", nameof(companyId));
            }

            return new Employee(new Guid(), name, companyId, roleId);
        }
    }
}
