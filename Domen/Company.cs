using System.Drawing;

namespace Domain
{
    public class Company
    {
        private Company(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; private init; }    
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Company Create(string name, string description)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            var company = new Company(new Guid(), name, description);

            return company;
        }

    }
}
