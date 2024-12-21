using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Role
    {
        private Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public static Role Create(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "Имя роли не может быть null.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя роли не может быть пустым или состоять только из пробелов.", nameof(name));
            }

            return new Role(new Guid(), name);
        }
    }
}
