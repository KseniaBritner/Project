using System.Drawing;

namespace Domain.Models
{
    public class Company
    {
        private Company(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Company Create(string name, string description)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(description);

            var company = new Company(new Guid(), name, description);

            return company;
        }
    }
}
